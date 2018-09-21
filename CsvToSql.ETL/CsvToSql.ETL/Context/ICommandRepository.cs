using CsvToSql.ETL.Models;
using System.Collections.Generic;

namespace CsvToSql.ETL.Context
{
	public interface ICommandRepository<T> where T : BaseModel
	{
		void Adicionar(T entity);

		void AdicionarRange(List<T> entity);
	}
}
