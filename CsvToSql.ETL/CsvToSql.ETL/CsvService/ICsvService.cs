using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvToSql.ETL.CsvService
{
	public interface ICsvService
	{
		Stream TratarInformacoesCsv(Stream csv);
	}
}
