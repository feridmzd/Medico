using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMedico.DAL;
using WebApplicationMedico.Models;

namespace WebApplicationMedico.Controllers
{
	public class HomeController : Controller
	{

		AppDbContext _dbcontext;

       public HomeController(AppDbContext dbcontext)
		{
			_dbcontext = dbcontext;
		}
        public IActionResult Index()
        {

			List<Doctors> doctors= _dbcontext.Doctors.ToList();

            return View(doctors);
        }











       

	

	}
}