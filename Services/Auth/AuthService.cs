using Core.Auth;
using Core.Domains.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public class AuthService : IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(ApplicationUser request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.PasswordHash))
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.UserName == "onur" && request.PasswordHash == "123456")
            {
                response.AccessTokenExpireDate = DateTime.UtcNow;
                response.AuthenticateResult = true;
                response.AuthToken = string.Empty;
            }

            return Task.FromResult(response);
        }
    }
}
