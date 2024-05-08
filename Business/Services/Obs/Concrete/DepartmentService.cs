using Business.Services.Obs.Abstract;
using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using System.Linq.Expressions;

namespace Business.Services.Obs.Concrete
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentDal _facultyDal;

        public DepartmentService(IDepartmentDal facultyDal)
        {
            _facultyDal = facultyDal;
        }

        public bool Any(Expression<Func<Department, bool>> filter)
        {
            return _facultyDal.Any(filter);
        }

        public Department Get(Expression<Func<Department, bool>> filter)
        {
            return _facultyDal.Get(filter);
        }

        public List<Department> GetList(Expression<Func<Department, bool>>? filter = null)
        {
            return _facultyDal.GetList(filter);
        }

        public Department Add(Department entity)
        {
            return _facultyDal.Add(entity);
        }

        public Department Update(Department entity)
        {
            return _facultyDal.Update(entity);
        }

        public Department Remove(Department entity)
        {
            return _facultyDal.Remove(entity);
        }
    }
}
