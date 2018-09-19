using System.Configuration;
using System.IO;
using System.Net;

namespace CsvToSql.ETL.FtpService
{
	public class FtpService : IFtpService
	{
		public TextReader BaixarCsvViaFTP()
		{
			var request = (FtpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ftpserver"].ToString());
			request.Method = WebRequestMethods.Ftp.DownloadFile;

			request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ftpusername"].ToString(), ConfigurationManager.AppSettings["ftppassword"].ToString());

			var response = (FtpWebResponse)request.GetResponse();

			var responseStream = response.GetResponseStream();

			TextReader csvText = new StreamReader(responseStream);

			return csvText;
		}
	}
}
