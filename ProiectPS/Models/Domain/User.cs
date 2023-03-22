using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProiectPS.Data;

namespace ProiectPS.Models.Domain
{
	public class User : IdentityUser
	{
        internal bool IsAccepted;

        public int Id { get; set; }
		//public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public Role Role { get; set; }
    }
}