using System.Linq.Expressions;

namespace Business.CommonServices.ICommonDbInterfaces
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
