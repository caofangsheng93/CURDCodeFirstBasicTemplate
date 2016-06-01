using Code_First.Data.Repository;
using CodeFirst.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Service
{
   public class PublisherService:IPublisherService
    {
       private IRepository<Publisher> _publisherRepository;
     

       public PublisherService(IRepository<Publisher> publisherRepository)
       {
           this._publisherRepository = publisherRepository;
       }

        public IQueryable<Publisher> GetAllPublisher()
        {
            return _publisherRepository.GetAll().AsQueryable();
            //throw new NotImplementedException();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherRepository.GetById(id);
            //throw new NotImplementedException();
        }

        public void InsertPublisher(Publisher model)
        {
            _publisherRepository.Insert(model);
            //throw new NotImplementedException();
        }

        public void UpdatePublisher(Publisher model)
        {
            _publisherRepository.Update(model);
            //throw new NotImplementedException();
        }

        public void DeletePublisher(int id)
        {
            _publisherRepository.Delete(id);
           // throw new NotImplementedException();
        }
    }
}
