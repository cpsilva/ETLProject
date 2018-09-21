using System.Net;

namespace CsvToSql.ETL.AmazonService
{
	public class S3Response
	{
		public HttpStatusCode HttpStatusCode { get; set; }
		public string Message { get; set; }
	}
}