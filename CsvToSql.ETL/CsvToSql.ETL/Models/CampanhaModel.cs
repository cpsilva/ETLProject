using System.ComponentModel.DataAnnotations;

namespace CsvToSql.ETL.Models
{
	public class CampanhaModel : BaseModel
	{
		[Key]
		public string nomeCampanha { get; set; }

		public int totalCliques { get; set; }
	}
}