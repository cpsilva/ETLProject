﻿using CsvToSql.ETL.Models;
using System.Collections.Generic;

namespace CsvToSql.ETL.SqlService
{
	public interface ISqlService
	{
		void GravarInformacaoBancoDados(List<CampanhaModel> Arquivo);
	}
}
