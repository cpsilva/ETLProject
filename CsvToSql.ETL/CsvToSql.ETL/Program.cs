using CsvToSql.ETL.EtlService;

namespace CsvToSql.ETL
{
	public class Program
	{
		private static IEtlService _etlService;

		public Program(IEtlService etlService)
		{
			_etlService = etlService;
		}

		static void Main(string[] args)
		{
			_etlService.Executar();
		}
	}
}
