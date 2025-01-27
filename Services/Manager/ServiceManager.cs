using AutoMapper;
using Core.Domains.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.EFCore;
using Services.Manager.Auth;
using Services.Manager.Contracts;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Manager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _authService;
        public ServiceManager(IRepositoryManager repositoryManager,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<Driver> userManager)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService(mapper, configuration,userManager));
        }
        public IAuthService Auth => _authService.Value;
    }
}
