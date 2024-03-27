using Entities.ObsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ObsDbContext.Ef.Dal.Abstract.CommonInterfaces
{
    public interface ICommonDal<T>
    {
        bool Any(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
