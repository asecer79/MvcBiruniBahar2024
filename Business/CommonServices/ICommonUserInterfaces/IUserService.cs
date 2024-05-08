using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CommonServices.ICommonDbInterfaces;
using Entities.CommonEntities;

namespace Business.CommonServices.ICommonUserInterfaces
{
    public interface IUserService:ICommonDbOperations<User>
    {
        User GetUserByEmailAndPassword(string email, string password);
        List<OperationClaim> GetUserOperationClaims(int userId);
    }
}
