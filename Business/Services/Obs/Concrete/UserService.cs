using Business.CommonServices.ICommonUserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.CommonEntities;
using DataAccess.ObsDbContext.Ef.Dal.Abstract;

namespace Business.Services.Obs.Concrete
{
    public class UserService:IUserService
    {
        IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool Any(Expression<Func<User, bool>> filter)
        {
            return _userDal.Any(filter);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
           return _userDal.Get(filter);
        }

        public List<User> GetList(Expression<Func<User, bool>>? filter = null)
        {
           return _userDal.GetList(filter);
        }

        public User Add(User entity)
        {
            return _userDal.Add(entity);
        }

        public User Update(User entity)
        {
            return _userDal.Update(entity);
        }

        public User Remove(User entity)
        {
            return _userDal.Remove(entity);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
           return _userDal.GetUserByEmailAndPassword(email, password);
        }

        public List<OperationClaim> GetUserOperationClaims(int userId)
        {
            return _userDal.GetUserOperationClaims(userId);
        }
    }
}
