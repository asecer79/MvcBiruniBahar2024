using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using System.Linq.Expressions;
using DataAccess.ObsDbContext.Ef.Repository;
using Entities.CommonEntities;

namespace DataAccess.ObsDbContext.Ef.Dal.Concrete
{
    public class UserOperationClaimDal:IUserOperationClaimDal
    {
        public bool Any(Expression<Func<UserOperationClaim, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.UserOperationClaims.Any(filter);
            }
        }

        public UserOperationClaim Get(Expression<Func<UserOperationClaim, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.UserOperationClaims.FirstOrDefault(filter);
            }
        }

        public List<UserOperationClaim> GetList(Expression<Func<UserOperationClaim, bool>>? filter=null)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                if (filter == null)
                    return context.UserOperationClaims.ToList();
                else
                    return context.UserOperationClaims.Where(filter).ToList();
            }
        }

        public UserOperationClaim Add(UserOperationClaim entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.UserOperationClaims.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public UserOperationClaim Update(UserOperationClaim entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.UserOperationClaims.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public UserOperationClaim Remove(UserOperationClaim entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.UserOperationClaims.Remove(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool BulkInsert(List<UserOperationClaim> list)
        {
            throw new NotImplementedException();
        }
    }
}
