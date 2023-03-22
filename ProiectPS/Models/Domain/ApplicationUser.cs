using Microsoft.AspNetCore.Identity;

namespace ProiectPS.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
