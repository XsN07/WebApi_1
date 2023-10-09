namespace P016_WeApi.Models
{
	public class Film
	{
		public int Id { get; set; }
		public string FilmAdi { get; set; }
		public string Yonetmen { get; set; }
		public string Basrol { get; set; }
		public int CikisYili { get; set; }
		public bool IsDeleted { get; set; } = false;
	}
}
