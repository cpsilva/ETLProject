using System;
using System.IO;
using System.Net;

namespace CsvToSql.ETL
{
	public class Program
	{
		static void Main(string[] args)
		{
			BaixarCsvViaFTP();
			TratarInformacoesCsv();
			GravarInformacaoBancoDados();
			SalvarCopiaCsvComResultadoS3();
		}

		private static void BaixarCsvViaFTP()
		{
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
			request.Method = WebRequestMethods.Ftp.DownloadFile;

			// Credenciais para logar.
			request.Credentials = new NetworkCredential("anonymous", "user");

			FtpWebResponse response = (FtpWebResponse)request.GetResponse();

			Stream responseStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(responseStream);
			Console.WriteLine(reader.ReadToEnd());

			reader.Close();
			response.Close();
		}

		private static void TratarInformacoesCsv()
		{
		}

		private static void GravarInformacaoBancoDados()
		{
		}

		private static void SalvarCopiaCsvComResultadoS3()
		{
		}
	}
}
