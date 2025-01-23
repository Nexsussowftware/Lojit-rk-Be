using Core.Domains.User;
using Core.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public interface IAuthService
    {
        public Task<IdentityResult> LoginUserAsync(UserForRegistrationDto request);
        Task<TokenDto> CreateToken(bool populateExp);

    }
}
