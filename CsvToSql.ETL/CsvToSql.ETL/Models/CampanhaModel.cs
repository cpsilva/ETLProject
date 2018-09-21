using System;
using System.Collections.Generic;
using System.Text;

namespace CsvToSql.ETL.Models
{
	public class CampanhaModel
	{
		public int id { get; set; }
		public string nomeCampanha { get; set; }
		public int totalCliques { get; set; }
	}
}
