using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using System.Linq.Expressions;
using DataAccess.ObsDbContext.Ef.Repository;
using Entities.CommonEntities;

namespace DataAccess.ObsDbContext.Ef.Dal.Concrete
{
    public class OperationClaimDal:IOperationClaimDal
    {
        public bool Any(Expression<Func<OperationClaim, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.OperationClaims.Any(filter);
            }
        }

        public OperationClaim Get(Expression<Func<OperationClaim, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.OperationClaims.FirstOrDefault(filter);
            }
        }

        public List<OperationClaim> GetList(Expression<Func<OperationClaim, bool>>? filter=null)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                if (filter == null)
                    return context.OperationClaims.ToList();
                else
                    return context.OperationClaims.Where(filter).ToList();
            }
        }

        public OperationClaim Add(OperationClaim entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.OperationClaims.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public OperationClaim Update(OperationClaim entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.OperationClaims.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public OperationClaim Remove(OperationClaim entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.OperationClaims.Remove(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool BulkInsert(List<OperationClaim> list)
        {
            throw new NotImplementedException();
        }
    }
}
