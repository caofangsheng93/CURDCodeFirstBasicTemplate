using CodeFirst.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Service
{
    public interface IPublisherService
    {
        IQueryable<Publisher> GetAllPublisher();

        Publisher GetPublisherById(int id);

        void InsertPublisher(Publisher model);

        void UpdatePublisher(Publisher model);

        void DeletePublisher(int id);
    }
}
