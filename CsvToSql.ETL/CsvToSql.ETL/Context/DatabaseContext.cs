using CsvToSql.ETL.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CsvToSql.ETL.Context
{
	public class DatabaseContext : DbContext
	{
		public DbSet<CampanhaModel> Campanhas { get; set; }

		public DatabaseContext()
		{
		}

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseMySql(ConfigurationManager.AppSettings["connectionString"].ToString());
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
