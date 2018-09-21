using CsvToSql.ETL.Models;
using System.Collections.Generic;
using System.IO;

namespace CsvToSql.ETL.CsvService
{
	public interface ICsvService
	{
		List<CampanhaModel> TratarInformacoesCsv(TextReader csv);
	}
}