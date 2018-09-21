using CsvToSql.ETL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CsvToSql.ETL.Context
{
	internal class CommandRepository<T> : ICommandRepository<T> where T : BaseModel
	{
		private DatabaseContext _databaseContext;

		public CommandRepository(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public void Adicionar(T entity)
		{
			_databaseContext.Set<T>().Add(entity);
		}

		public void AdicionarRange(List<T> entity)
		{
			_databaseContext.Set<T>().AddRange(entity);
		}
	}
}