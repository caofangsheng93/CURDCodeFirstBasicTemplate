using CodeFirst.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Service
{
   public interface IBookService
    {
       IQueryable<Book> GetAllBooks();

       Book GetBookById(int id);

       void InsertBook(Book model);

       void UpdateBook(Book model);

       void DeleteBook(int id);

       void Save();
    }
}
