using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Obs.Abstract.ICommonInterfaces
{
    public interface ICommonDbOperations<T>
    {
        bool Any(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>>? filter = null);
        T Add(T entity);
        T Update(T entity);
        T Remove(T entity);
    }
}
