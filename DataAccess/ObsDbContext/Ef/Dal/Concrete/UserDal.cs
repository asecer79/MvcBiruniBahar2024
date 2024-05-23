using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using System.Linq.Expressions;
using DataAccess.ObsDbContext.Ef.Repository;
using Entities.CommonEntities;

namespace DataAccess.ObsDbContext.Ef.Dal.Concrete
{
    public class UserDal:IUserDal
    {
        public bool Any(Expression<Func<User, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.Users.Any(filter);
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.Users.FirstOrDefault(filter);
            }
        }

        public List<User> GetList(Expression<Func<User, bool>>? filter=null)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                if (filter == null)
                    return context.Users.ToList();
                else
                    return context.Users.Where(filter).ToList();
            }
        }

        public User Add(User entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public User Update(User entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Users.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public User Remove(User entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Users.Remove(entity);
                context.SaveChanges();
                return entity;
            }
        }


        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.Users.FirstOrDefault(p=>p.Email==email&& p.Password==password);
            }
        }

        public List<OperationClaim> GetUserOperationClaims(int userId)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                var data = context.UserOperationClaims.Where(p => p.UserId == userId).Select(p => p.OperationClaim)
                    .ToList();

                return data;
            }
        }
    }
}
