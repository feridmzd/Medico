using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationMedico.Models;

namespace WebApplicationMedico.DAL
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{


		}

	public 	DbSet<Doctors>Doctors { get; set; }
	}
}
