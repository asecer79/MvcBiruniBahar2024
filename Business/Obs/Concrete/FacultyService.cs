using Business.Obs.Abstract;
using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using Caching.Abstract;

namespace Business.Obs.Concrete
{
    public class FacultyService : IFacultyService
    {
        static HashSet<string> keys = new HashSet<string>();

        private ICacheProvider _cacheProvider;

        private IFacultyDal _facultyDal;

        public FacultyService(IFacultyDal facultyDal, ICacheProvider cacheProvider)
        {
            _facultyDal = facultyDal;
            _cacheProvider = cacheProvider;
        }

        public bool Any(Expression<Func<Faculty, bool>> filter)
        {
            return _facultyDal.Any(filter);
        }

        public Faculty Get(Expression<Func<Faculty, bool>> filter)
        {
            return _facultyDal.Get(filter);
        }

        public List<Faculty> GetList(Expression<Func<Faculty, bool>>? filter = null)
        {

            var param = filter == null ? "" : filter.ToString();

            var key = $"IFacultyService.GetList{param}" ;
            
            using (var sha256 =SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                var hashString = BitConverter.ToString(hashBytes).Replace("-", "");
                key = hashString;
            }

            keys.Add(key);

            if (!_cacheProvider.Any(key))
            {
                //Thread.Sleep(10000);
                var freshData = _facultyDal.GetList(filter);
                _cacheProvider.Set<List<Faculty>>(key, freshData, TimeSpan.FromSeconds(600));

                return freshData;
            }


            var cachedData = _cacheProvider.Get<List<Faculty>>(key);

            return cachedData;
        }

        public Faculty Add(Faculty entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }
            return _facultyDal.Add(entity);
        }

        public Faculty Update(Faculty entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }
            return _facultyDal.Update(entity);
        }

        public Faculty Remove(Faculty entity)
        {
            foreach (var key in keys)
            {
                _cacheProvider.Remove(key);
            }

            return _facultyDal.Remove(entity);
        }
    }
}
