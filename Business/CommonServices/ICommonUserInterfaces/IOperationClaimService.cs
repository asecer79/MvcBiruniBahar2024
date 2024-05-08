using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CommonServices.ICommonDbInterfaces;
using Entities.CommonEntities;

namespace Business.CommonServices.ICommonUserInterfaces
{
    public interface IOperationClaimService:ICommonDbOperations<OperationClaim>
    {
    }
}
