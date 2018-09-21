using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using CsvHelper;
using CsvToSql.ETL.Models;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CsvToSql.ETL.AmazonService
{
	public class AmazonService : IAmazonService
	{
		private string bucketName = ConfigurationManager.AppSettings["bucketpaths3"].ToString();
		private RegionEndpoint bucketRegion = RegionEndpoint.SAEast1;
		private AmazonS3Client s3Client { get; set; }
		private TextWriter writer { get; set; }

		public AmazonService()
		{
			s3Client = new AmazonS3Client(ConfigurationManager.AppSettings["chaveacesso"].ToString(), ConfigurationManager.AppSettings["chavesecreta"].ToString(), bucketRegion);
		}

		public async Task<S3Response> SalvarCopiaCsvComResultadoS3(List<CampanhaModel> listaCampanhaModels)
		{
			var mem = new MemoryStream();
			var writer = new StreamWriter(mem);
			var csvWriter = new CsvWriter(writer);

			csvWriter.Configuration.Delimiter = ";";
			csvWriter.Configuration.HasHeaderRecord = true;
			csvWriter.Configuration.AutoMap<CampanhaModel>();

			csvWriter.WriteHeader<CampanhaModel>();
			csvWriter.WriteRecords(listaCampanhaModels);
			writer.Flush();

			mem.Seek(0, SeekOrigin.Begin);

			var a = new Attachment(mem, "Campanhas.csv");

			PutObjectRequest putObjectRequest = new PutObjectRequest()
			{
				BucketName = bucketName,
				InputStream = a.ContentStream,
				ContentType = a.ContentType.ToString()
			};

			PutObjectResponse response = await s3Client.PutObjectAsync(putObjectRequest);

			return new S3Response()
			{
				HttpStatusCode = response.HttpStatusCode
			};
		}
	}
}