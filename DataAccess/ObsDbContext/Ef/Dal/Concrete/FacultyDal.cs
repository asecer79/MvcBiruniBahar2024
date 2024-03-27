using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;

namespace DataAccess.ObsDbContext.Ef.Dal.Concrete
{
    public class FacultyDal:IFacultyDal
    {
        public bool Any(Expression<Func<Faculty, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Faculty Get(Expression<Func<Faculty, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Faculty> GetList(Expression<Func<Faculty, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Faculty Add(Faculty entity)
        {
            throw new NotImplementedException();
        }

        public Faculty Update(Faculty entity)
        {
            throw new NotImplementedException();
        }

        public Faculty Delete(Faculty entity)
        {
            throw new NotImplementedException();
        }

        public bool BulkInsert(List<Faculty> list)
        {
            throw new NotImplementedException();
        }
    }
}
