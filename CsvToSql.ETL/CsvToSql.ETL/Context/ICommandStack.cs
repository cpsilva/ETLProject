using CsvToSql.ETL.Models;

namespace CsvToSql.ETL.Context
{
	public interface ICommandStack
	{
		ICommandRepository<CampanhaModel> caiopires { get; }

		void SaveChanges();
	}
}