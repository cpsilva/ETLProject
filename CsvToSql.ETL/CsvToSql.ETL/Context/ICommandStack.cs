using CsvToSql.ETL.Models;

namespace CsvToSql.ETL.Context
{
	public interface ICommandStack
	{
		ICommandRepository<CampanhaModel> Campanha { get; }

		void SaveChanges();
	}
}