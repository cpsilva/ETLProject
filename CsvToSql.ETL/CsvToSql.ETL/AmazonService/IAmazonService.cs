using CsvToSql.ETL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsvToSql.ETL.AmazonService
{
	public interface IAmazonService
	{
		Task<S3Response> SalvarCopiaCsvComResultadoS3(List<CampanhaModel> listaCampanhaModels);
	}
}