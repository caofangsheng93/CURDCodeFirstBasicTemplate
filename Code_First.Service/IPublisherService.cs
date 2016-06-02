using CodeFirst.Entities.Entities;
using System.Linq;

namespace Code_First.Service
{
    public interface IPublisherService
    {
        IQueryable<Publisher> GetAllPublisher();

        Publisher GetPublisherById(int id);

        void InsertPublisher(Publisher model);

        void UpdatePublisher(Publisher model);

        void DeletePublisher(int id);

        void Save();
    }
}
