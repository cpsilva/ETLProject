using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvToSql.ETL.FtpService
{
	public interface IFtpService
	{
		Stream BaixarCsvViaFTP();
	}
}
