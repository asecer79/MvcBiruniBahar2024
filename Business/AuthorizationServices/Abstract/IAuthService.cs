using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AuthorizationServices.Abstract
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string email, string password);
        Task SignOutAsync();
    }
}
