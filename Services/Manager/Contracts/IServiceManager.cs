using Services.Manager.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Manager.Contracts
{
    public interface IServiceManager
    {
        IAuthService Auth { get; }
    }
}
