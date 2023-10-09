namespace P016_WeApi.Dtos
{
	public class FilmDto
	{
		public int Id { get; set; }
		public string? FilmAdi { get; set; }
		public string? Yonetmen { get; set; }
		public string? Basrol { get; set; }
		public int? CikisYili { get; set; } = 1700;
		public bool IsDeleted { get; set; } = false;
	}
}
