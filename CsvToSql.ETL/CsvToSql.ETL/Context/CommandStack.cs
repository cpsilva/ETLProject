using System;
using System.Collections.Generic;
using System.Text;
using CsvToSql.ETL.Models;

namespace CsvToSql.ETL.Context
{
	public class CommandStack : ICommandStack
	{
		public ICommandRepository<CampanhaModel> Campanha { get; }

		private DatabaseContext DatabaseContext { get; }

		public CommandStack(DatabaseContext databaseContext)
		{
			DatabaseContext = databaseContext;

			Campanha = new CommandRepository<CampanhaModel>(DatabaseContext);
		}

		public void SaveChanges()
		{
			DatabaseContext.SaveChanges();
		}
	}
}
