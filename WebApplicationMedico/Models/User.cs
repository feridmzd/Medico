using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplicationMedico.Models
{
	public class User:IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}
