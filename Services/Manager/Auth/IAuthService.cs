using Core.Domains.User;
using Core.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Manager.Auth
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto request);
        Task<TokenDto> CreateToken(bool populateExp);

    }
}
