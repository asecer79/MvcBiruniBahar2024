using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ObsDbContext.Ef.Dal.Abstract.CommonInterfaces;
using Entities.CommonEntities;
using Entities.ObsEntities;

namespace DataAccess.ObsDbContext.Ef.Dal.Abstract
{
    public interface IOperationClaimDal : ICommonDal<OperationClaim>
    {
       
    }
}
