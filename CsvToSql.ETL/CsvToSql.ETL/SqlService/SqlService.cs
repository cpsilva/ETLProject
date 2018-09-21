using CsvToSql.ETL.Context;
using CsvToSql.ETL.Models;
using System.Collections.Generic;

namespace CsvToSql.ETL.SqlService
{
	public class SqlService : ISqlService
	{
		private IUnitOfWork _unit;

		public SqlService(IUnitOfWork unit)
		{
			_unit = unit;
		}

		public void GravarListaDeCampanhasAgrupadasEOrdenadas(List<CampanhaModel> listaCampanhaModel)
		{
			_unit.CommandStack.Campanha.AdicionarRange(listaCampanhaModel);
			_unit.CommandStack.SaveChanges();
		}
	}
}
