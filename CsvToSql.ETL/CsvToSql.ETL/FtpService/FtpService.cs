using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CsvToSql.ETL.FtpService
{
	public class FtpService : IFtpService
	{
		public Stream BaixarCsvViaFTP()
		{
			// Extrair para config
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
			request.Method = WebRequestMethods.Ftp.DownloadFile;

			// Credenciais para logar.
			// Extrair para config
			request.Credentials = new NetworkCredential("anonymous", "user");

			FtpWebResponse response = (FtpWebResponse)request.GetResponse();

			Stream responseStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(responseStream);
			Console.WriteLine(reader.ReadToEnd());

			reader.Close();
			response.Close();

			return responseStream;
		}
	}
}
