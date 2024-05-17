using Microsoft.AspNetCore.Mvc;
using WebApplicationMedico.DAL;
using WebApplicationMedico.Models;
using WebApplicationMedico.ViewModel.Doctors;

namespace WebApplicationMedico.Areas.Manage.Controllers
{

	[Area("Manage")]
	public class DoctorsController : Controller
	{
        public AppDbContext _context { get; }
        public IWebHostEnvironment _environment { get; }

        public DoctorsController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
		{

            var doctors = _context.Doctors.ToList();
			return View(doctors);
		}

		public IActionResult Create()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Create(CreateDoctorsVm doctorsVm)
        {

            if(!doctorsVm.ImgFile.ContentType.Contains("image/"))
            {


                ModelState.AddModelError("ImgFile","Sehvlik Var");
                return View();
            }
            string path = _environment.WebRootPath + @"\Upload\Doctors\";
            string filename = Guid.NewGuid() + doctorsVm.ImgFile.FileName;


            using (FileStream fileStream = new FileStream(path+filename,FileMode.Create))
            {
                doctorsVm.ImgFile.CopyTo(fileStream);
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            Doctors doctors = new Doctors()
            {
                Name = doctorsVm.Name,
                Description = doctorsVm.Description,
                ImgUrl = filename,

            };
            _context.Doctors.Add(doctors);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);

            if (doctor != null)
            {
                string path = _environment.WebRootPath + @"\Upload\Doctors\" +doctor.ImgUrl;
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }
        public IActionResult Update(int id)
        {

            Doctors doctors = _context.Doctors.FirstOrDefault(x => x.Id == id);
            UpdateDoctorsVm doctorsVm = new UpdateDoctorsVm()
            {

                Id = doctors.Id,
                Name = doctors.Name,
                Description = doctors.Description,
                ImgUrl = doctors.ImgUrl
            };

            if (doctors == null)
            {
                return RedirectToAction("Index");
            }
            return View(doctorsVm);
        }
        [HttpPost]

        public IActionResult Update(UpdateDoctorsVm service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var olddoctors = _context.Doctors.FirstOrDefault(x => x.Id == service.Id);
            if (olddoctors == null) { return RedirectToAction("Index"); }
            olddoctors.Name = service.Name;
            olddoctors.Description = service.Description;
            olddoctors.ImgUrl = service.ImgUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }


    }

