namespace CsvToSql.ETL.Models
{
	public class CampanhaModel : BaseModel
	{
		public int id { get; set; }
		public string nomeCampanha { get; set; }
		public int totalCliques { get; set; }
	}
}
