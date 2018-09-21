using CsvToSql.ETL.Models;

namespace CsvToSql.ETL.Context
{
	public class caiopires : BaseModel
	{
		public int id { get; set; }
		public string nomeCampanha { get; set; }
		public int totalCliques { get; set; }
	}
}