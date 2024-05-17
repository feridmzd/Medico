using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebApplicationMedico.Models
{
	public class Doctors
	{

		public int Id { get; set; }
		public string Name { get; set; }
		[StringLength(25, ErrorMessage = "Uzlug 25 i kece bilmez")]
		public string Description { get; set; }
		public string? ImgUrl { get; set; }
	}
}
