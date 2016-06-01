using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First.Data.Repository
{
    /// <summary>
    /// 泛型仓储接口
    /// </summary>
   public interface IRepository<T> where T:class
    {
       /// <summary>
       /// 获取所有
       /// </summary>
       /// <returns></returns>
       IEnumerable<T> GetAll();

       /// <summary>
       /// 根据ID获取
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       T GetById(object id);

       /// <summary>
       /// 增加
       /// </summary>
       /// <param name="model"></param>
       void Insert(T model);

       /// <summary>
       /// 删除
       /// </summary>
       /// <param name="id"></param>
       void Delete(object id);

       /// <summary>
       /// 更新
       /// </summary>
       /// <param name="model"></param>
       void Update(T model);

       /// <summary>
       /// 保存
       /// </summary>
       void Save();


    }
}
