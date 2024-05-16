using Microsoft.EntityFrameworkCore;
using DesafioWPF.Models;

namespace DesafioWPF.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}

		public DbSet<Pedidos> Pedidos { get; set; }
	}
}
