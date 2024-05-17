using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationMedico.DAL;
using WebApplicationMedico.Models;

namespace WebApplicationMedico
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();


			builder.Services.AddIdentity<User, IdentityRole>(opt =>
			{
				opt.Password.RequiredLength = 8;
				opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
				opt.Lockout.AllowedForNewUsers = false;
				opt.Lockout.MaxFailedAccessAttempts = 3;
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
				opt.User.RequireUniqueEmail = true;
			}).AddEntityFrameworkStores<AppDbContext>();


			builder.Services.AddDbContext<AppDbContext>(opt=>
			{

				opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
			}
			
			
			);




			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();


			app.MapControllerRoute(
		   name: "areas",
		   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		 );
		

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}