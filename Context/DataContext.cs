using Microsoft.EntityFrameworkCore;
using P016_WeApi.Models;

namespace P016_WeApi.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<Film> Film { get; set; }
	}
}
