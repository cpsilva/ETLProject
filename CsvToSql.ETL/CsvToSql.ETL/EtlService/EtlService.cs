using CsvToSql.ETL.AmazonService;
using CsvToSql.ETL.CsvService;
using CsvToSql.ETL.FtpService;
using CsvToSql.ETL.SqlService;


namespace CsvToSql.ETL.EtlService
{
	public class EtlService : IEtlService
	{
		private IAmazonService _amazonService;
		private ICsvService _csvService;
		private IFtpService _ftpService;
		private ISqlService _sqlService;

		public EtlService(IAmazonService amazonService, ICsvService csvService, IFtpService ftpService, ISqlService sqlService)
		{
			_amazonService = amazonService;
			_csvService = csvService;
			_ftpService = ftpService;
			_sqlService = sqlService;
		}

		public void Executar()
		{
			var arquivo = _ftpService.BaixarCsvViaFTP();
			_csvService.TratarInformacoesCsv(arquivo);
			//_sqlService.GravarInformacaoBancoDados(arquivo);
			//_amazonService.SalvarCopiaCsvComResultadoS3(arquivo);
		}
	}
}
