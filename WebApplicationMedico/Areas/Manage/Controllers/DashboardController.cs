using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMedico.Areas.Manage.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
