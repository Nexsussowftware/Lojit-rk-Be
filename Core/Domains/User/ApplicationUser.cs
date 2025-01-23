using Core.Enums.User;
using Microsoft.AspNetCore.Identity;

namespace Core.Domains.User
{
    public class ApplicationUser : IdentityUser<int>
    {
        /// <summary>
        /// Kullanıcı tipi Id
        /// </summary>
        public int UserTypeId { get; set; }
        //====================================================================================================
        /// <summary>
        /// Admin = 1, Company = 2, Driver = 3, Customer = 4
        /// </summary>
        public UserType UserType { get; set; }
        //====================================================================================================
        /// <summary>
        /// Kullanıcı tipi adı
        /// <summary/>
        public string UserTypeName { get; set; }
        //====================================================================================================
        public String? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
