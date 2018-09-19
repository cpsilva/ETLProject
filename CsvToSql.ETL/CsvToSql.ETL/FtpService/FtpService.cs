using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace CsvToSql.ETL.FtpService
{
	public class FtpService : IFtpService
	{
		public Stream BaixarCsvViaFTP()
		{
			FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ftpserver"].ToString());
			request.Method = WebRequestMethods.Ftp.DownloadFile;

			request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());

			FtpWebResponse response = (FtpWebResponse)request.GetResponse();

			Stream responseStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(responseStream);
			Console.WriteLine(reader.ReadToEnd());
			Console.ReadKey();

			reader.Close();
			response.Close();

			return responseStream;
		}
	}
}
