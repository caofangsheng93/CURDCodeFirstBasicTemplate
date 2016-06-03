using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Entities.Entities;
using Code_First.Data.DbContextClass;
using Code_First.Service;
using Code_First_CURD.Models;

namespace Code_First_CURD.Controllers
{
    public class BooksController : Controller
    {
        private IBookService _IBookservice;
        private IPublisherService _IPublisherService;
        public BooksController(IBookService IBookservice, IPublisherService IPublisherService)
        {
            this._IBookservice = IBookservice;
            this._IPublisherService = IPublisherService;
        }

        // GET: Books
        public ActionResult Index()
        {
           
            var books = _IBookservice.GetAllBooks().Include(b => b.Publisher);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Book book =_IBookservice.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            //显示为DropDownList
            ViewBag.PublisherId = new SelectList(_IPublisherService.GetAllPublisher(), "PublisherId", "PublisherName");
            return View();   
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "BookId,Title,Year,PublisherId")] 
            Book book)
        {
            if (ModelState.IsValid)
            {
                _IBookservice.InsertBook(book);
                _IBookservice.Save();
                return RedirectToAction("Index");
            }

            ViewBag.PublisherId = new SelectList(_IPublisherService.GetAllPublisher(), "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _IBookservice.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublisherId = new SelectList(_IPublisherService.GetAllPublisher(), "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "BookId,Title,Year,PublisherId")]
            Book book)
        {
            if (ModelState.IsValid)
            {
                _IBookservice.UpdateBook(book);
                _IBookservice.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PublisherId = new SelectList(_IPublisherService.GetAllPublisher(), "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

      
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _IBookservice.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            _IBookservice.DeleteBook(id);
            _IBookservice.Save();
            return RedirectToAction("Index");
        }


        public PartialViewResult GetBookByPublishId(int id)
        {
            IEnumerable<BookModel> model = new List<BookModel>(); //用于显示Book的信息
            IEnumerable<Book> lstBook = _IBookservice.GetAllBooks().Where(s => s.PublisherId == id).ToList();
            model = lstBook.Select(x => new BookModel() 
            { 
            BoodId=x.BookId,
            Title=x.Title,
            Year=x.Year

            }).ToList();//这里需要强制转化为List类型，不然加载不了分部视图，有错误，因为：分部视图中是：@model  List<Code_First_CURD.Models.BookModel> 
            return PartialView(model);
        }


        public JsonResult JsonGetBookByPublishId(int id)
        {
            IEnumerable<BookModel> model = new List<BookModel>();
            IEnumerable<Book> lstBook = _IBookservice.GetAllBooks().Where(s => s.PublisherId == id).ToList();
            model = lstBook.Select(x => new BookModel() 
            { 
            BoodId=x.BookId,
            Title=x.Title,
            Year=x.Year
            
            }).ToList();

            return Json(model, JsonRequestBehavior.AllowGet);  //JsonRequestBehavior.AllowGet不能少
        }

       
    }
}
