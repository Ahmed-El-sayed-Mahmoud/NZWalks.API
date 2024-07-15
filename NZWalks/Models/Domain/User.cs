using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domain
{
    public class User:IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //[NotMapped]
        //public List<string> Roles { get; set; }

        // Navigation property
       // public List<User_Role> UserRoles { get; set; }
    }
}
