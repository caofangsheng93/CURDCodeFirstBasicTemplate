using Code_First.Data.DbContextClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Data.Repository
{
    /// <summary>
    /// 泛型仓储类，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class Repository<T>:IRepository<T> where T:class
    {
       private Code_First_DbContext db;
       private DbSet<T> dbSet;

       public Repository()
       {
           this.db = new Code_First_DbContext();
           dbSet = db.Set<T>();
       }

        public IEnumerable<T> GetAll()
        {
           return dbSet.ToList();
           //return db.Set<T>().ToList();
            //throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
            //throw new NotImplementedException();
        }

        public void Insert(T model)
        {
             db.Entry<T>(model).State = EntityState.Added;
            //throw new NotImplementedException();
        }

        public void Delete(object id)
        {
          T delModel = db.Set<T>().Find(id);
          db.Entry(delModel).State = EntityState.Deleted;
            //throw new NotImplementedException();
        }

        public void Update(T model)
        {
            db.Entry(model).State = EntityState.Modified;
            //throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
           // throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }

        }
    }
}
