using CsvToSql.ETL.Context;
using CsvToSql.ETL.EtlService;
using System.Configuration;

namespace CsvToSql.ETL
{
	public class Program
	{
		static void Main(string[] args)
		{
			Container.RegisterServices();
			Container.AddDbContext<DatabaseContext>(ConfigurationManager.AppSettings["connectionString"].ToString());

			var _etlService = Container.GetService<IEtlService>();

			_etlService.Executar();
		}
	}
}
