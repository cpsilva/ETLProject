using CsvToSql.ETL.Models;

namespace CsvToSql.ETL.Context
{
	public class CommandStack : ICommandStack
	{
		private DatabaseContext DatabaseContext { get; }
		public ICommandRepository<CampanhaModel> caiopires { get; }

		public CommandStack(DatabaseContext databaseContext)
		{
			DatabaseContext = databaseContext;

			caiopires = new CommandRepository<CampanhaModel>(DatabaseContext);
		}

		public void SaveChanges()
		{
			DatabaseContext.SaveChanges();
		}
	}
}