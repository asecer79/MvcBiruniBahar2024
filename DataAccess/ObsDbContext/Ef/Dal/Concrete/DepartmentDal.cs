using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using DataAccess.ObsDbContext.Ef.Repository;
using Entities.ObsEntities;

namespace DataAccess.ObsDbContext.Ef.Dal.Concrete
{
    public class DepartmentDal : IDepartmentDal
    {
        public bool Any(Expression<Func<Department, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.Departments.Any(filter);
            }
        }

        public Department Get(Expression<Func<Department, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.Departments.FirstOrDefault(filter);
            }
        }

        public List<Department> GetList(Expression<Func<Department, bool>>? filter = null)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                if (filter == null)
                    return context.Departments.ToList();
                else
                    return context.Departments.Where(filter).ToList();

            }
        }

        public Department Add(Department entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Departments.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Department Update(Department entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Departments.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Department Remove(Department entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Departments.Remove(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool BulkInsert(List<Department> list)
        {
            throw new NotImplementedException();
        }
    }
}
