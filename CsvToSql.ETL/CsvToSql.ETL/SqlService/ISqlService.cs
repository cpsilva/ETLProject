using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvToSql.ETL.SqlService
{
	public interface ISqlService
	{
		void GravarInformacaoBancoDados(Stream Arquivo);
	}
}
