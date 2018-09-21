using System;

namespace CsvToSql.ETL.Models
{
	public class CampanhaModel : BaseModel
	{
		public Guid id { get; set; }
		public string nomeCampanha { get; set; }
		public int totalCliques { get; set; }
	}
}