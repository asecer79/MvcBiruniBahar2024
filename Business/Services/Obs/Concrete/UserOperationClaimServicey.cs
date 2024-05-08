using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using Business.CommonServices.ICommonUserInterfaces;
using Caching.Abstract;
using Business.Services.Obs.Abstract;
using Entities.CommonEntities;

namespace Business.Services.Obs.Concrete
{
    public class UserOperationClaimService : IUserOperationClaimService
    {
        static HashSet<string> keys = new HashSet<string>();

        private ICacheProvider _cacheProvider;

        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimService(IUserOperationClaimDal userOperationClaimDal, ICacheProvider cacheProvider)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _cacheProvider = cacheProvider;
        }

        public bool Any(Expression<Func<UserOperationClaim, bool>> filter)
        {
            return _userOperationClaimDal.Any(filter);
        }

        public UserOperationClaim Get(Expression<Func<UserOperationClaim, bool>> filter)
        {
            return _userOperationClaimDal.Get(filter);
        }

        public List<UserOperationClaim> GetList(Expression<Func<UserOperationClaim, bool>>? filter = null)
        {

            var param = filter == null ? "" : filter.ToString();

            var key = $"IUserOperationClaimService.GetList{param}";

            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                var hashString = BitConverter.ToString(hashBytes).Replace("-", "");
                key = hashString;
            }

            keys.Add(key);

            if (!_cacheProvider.Any(key))
            {
                //Thread.Sleep(10000);
                var freshData = _userOperationClaimDal.GetList(filter);
                _cacheProvider.Set(key, freshData, TimeSpan.FromSeconds(600));

                return freshData;
            }


            var cachedData = _cacheProvider.Get<List<UserOperationClaim>>(key);

            return cachedData;
        }

        public UserOperationClaim Add(UserOperationClaim entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }
            return _userOperationClaimDal.Add(entity);
        }

        public UserOperationClaim Update(UserOperationClaim entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }
            return _userOperationClaimDal.Update(entity);
        }

        public UserOperationClaim Remove(UserOperationClaim entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }

            return _userOperationClaimDal.Remove(entity);
        }
    }
}
