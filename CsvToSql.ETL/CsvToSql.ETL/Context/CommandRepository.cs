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

		public void Atualizar(T entity)
		{
			var e = _databaseContext.Entry(entity);
			_databaseContext.Entry(entity).State = EntityState.Modified;
		}

		public void Apagar(int id)
		{
			var entityTrackeable = _databaseContext.Set<T>().Find(id);
			if (entityTrackeable == null) { return; }
			_databaseContext.Set<T>().Remove(entityTrackeable);
		}
	}
}