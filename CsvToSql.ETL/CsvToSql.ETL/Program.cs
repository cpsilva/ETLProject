using CsvToSql.ETL.EtlService;

namespace CsvToSql.ETL
{
	public class Program
	{

		static void Main(string[] args)
		{
			Container.RegisterServices();

			var _etlService = Container.GetService<IEtlService>();

			_etlService.Executar();
		}
	}
}
