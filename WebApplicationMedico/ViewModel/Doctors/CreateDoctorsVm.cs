namespace WebApplicationMedico.ViewModel.Doctors
{
	public class CreateDoctorsVm
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public IFormFile ImgFile { get; set; }
	}
}
