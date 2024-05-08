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
    public class OperationClaimService : IOperationClaimService
    {
        static HashSet<string> keys = new HashSet<string>();

        private ICacheProvider _cacheProvider;

        private IOperationClaimDal _operationClaimDal;

        public OperationClaimService(IOperationClaimDal operationClaimDal, ICacheProvider cacheProvider)
        {
            _operationClaimDal = operationClaimDal;
            _cacheProvider = cacheProvider;
        }

        public bool Any(Expression<Func<OperationClaim, bool>> filter)
        {
            return _operationClaimDal.Any(filter);
        }

        public OperationClaim Get(Expression<Func<OperationClaim, bool>> filter)
        {
            return _operationClaimDal.Get(filter);
        }

        public List<OperationClaim> GetList(Expression<Func<OperationClaim, bool>>? filter = null)
        {

            var param = filter == null ? "" : filter.ToString();

            var key = $"IOperationClaimService.GetList{param}";

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
                var freshData = _operationClaimDal.GetList(filter);
                _cacheProvider.Set(key, freshData, TimeSpan.FromSeconds(600));

                return freshData;
            }


            var cachedData = _cacheProvider.Get<List<OperationClaim>>(key);

            return cachedData;
        }

        public OperationClaim Add(OperationClaim entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }
            return _operationClaimDal.Add(entity);
        }

        public OperationClaim Update(OperationClaim entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }
            return _operationClaimDal.Update(entity);
        }

        public OperationClaim Remove(OperationClaim entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }

            return _operationClaimDal.Remove(entity);
        }
    }
}
