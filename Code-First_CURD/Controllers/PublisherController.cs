using Code_First.Service;
using Code_First_CURD.Models;
using CodeFirst.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_First_CURD.Controllers
{
    public class PublisherController : Controller
    {
        private IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this._publisherService = publisherService;
        }
        // GET: Publisher
        public ActionResult Index()
        {
            IQueryable<Publisher> model = _publisherService.GetAllPublisher();
            return View(model);
        }

        public ActionResult CreatePublisher()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreatePublisher(Publisher model)
        {
            try
            {
                Publisher publishModel = new Publisher()
                {
                    PublisherName = model.PublisherName,
                    Address = model.Address
                };
                _publisherService.InsertPublisher(publishModel);
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        public ActionResult UpdatePublisher(int id)
        {
          Publisher model=  _publisherService.GetPublisherById(id);
          return View(model);  
        }

        [HttpPost]
        public ActionResult UpdatePublisher(Publisher model)
        {
            try
            {
                _publisherService.UpdatePublisher(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
           
        }

        public ActionResult DeletePublisher(int id)
        {
            if (id != 0)
            {
             Publisher publisherModel= _publisherService.GetPublisherById(id);
             return View(publisherModel);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult DeletePublisher(int id, FormCollection collection)
        {

            if (id != 0)
            {
                _publisherService.DeletePublisher(id);
                
                return RedirectToAction("Index");
            }
            else  
            {
                return View();
            }
            
        }

    }
}