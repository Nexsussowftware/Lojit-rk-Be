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
        [Required(ErrorMessage ="Zorunlu")]
        public string FirstName { get; init; }
        //====================================================================================================
        [Required(ErrorMessage ="Zorunlu")]
        public string Password { get; init; }
        //====================================================================================================
        public ICollection<string>? Roles { get; init; }

    }
}
