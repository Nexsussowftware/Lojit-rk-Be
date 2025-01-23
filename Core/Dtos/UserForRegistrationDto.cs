using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserForRegistrationDto
    {
        public string FirstName { get; set; }
        //====================================================================================================
        public string Password { get; set; }
        //====================================================================================================
        public ICollection<string>? Roles { get; init; }

    }
}
