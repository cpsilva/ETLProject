using CsvToSql.ETL.AmazonService;
using CsvToSql.ETL.CsvService;
using CsvToSql.ETL.FtpService;
using CsvToSql.ETL.SqlService;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsvToSql.ETL.EtlService
{
	public class EtlService : IEtlService
	{
		//Necessario configurar o container
		private IAmazonService _amazonService { get; } = new AmazonService.AmazonService();
		private ICsvService _csvService { get; } = new CsvService.CsvService();
		private IFtpService _ftpService { get; } = new FtpService.FtpService();
		private ISqlService _sqlService { get; } = new SqlService.SqlService();

		public EtlService()
		{

		}

		public void Executar()
		{
			var arquivo = _ftpService.BaixarCsvViaFTP();
			_csvService.TratarInformacoesCsv(arquivo);
			_sqlService.GravarInformacaoBancoDados(arquivo);
			_amazonService.SalvarCopiaCsvComResultadoS3(arquivo);
		}
	}
}
