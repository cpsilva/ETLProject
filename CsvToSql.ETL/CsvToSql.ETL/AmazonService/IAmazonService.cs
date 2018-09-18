using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvToSql.ETL.AmazonService
{
	public interface IAmazonService
	{
		void SalvarCopiaCsvComResultadoS3(Stream csv);
	}
}
