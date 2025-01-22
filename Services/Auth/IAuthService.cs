using Core.Auth;
using Core.Domains.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(ApplicationUser request);
    }
}
