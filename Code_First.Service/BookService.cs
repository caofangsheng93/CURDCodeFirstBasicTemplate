using Code_First.Data.Repository;
using CodeFirst.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Service
{
   public class BookService:IBookService
    {
       private Repository<Book> _bookRepository;

       public BookService(Repository<Book> bookRepository)
       {
           this._bookRepository = bookRepository;
       }
        public IQueryable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().AsQueryable();
            //throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
            //throw new NotImplementedException();
        }

        public void InsertBook(Book model)
        {
            _bookRepository.Insert(model);
            //throw new NotImplementedException();
        }

        public void UpdateBook(Book model)
        {
            _bookRepository.Update(model);
            //throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
            //throw new NotImplementedException();
        }

        public void Save()
        {
            _bookRepository.Save();
           // throw new NotImplementedException();
        }
    }
}
