using CsvHelper;
using CsvToSql.ETL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsvToSql.ETL.CsvService
{
	public class CsvService : ICsvService
	{
		public void TratarInformacoesCsv(TextReader csv)
		{
			var listaCsvBruta = ConverteCsvParaListaDeCsvModel(csv);

			var listaCsvNomeTratado = TratarNomeDaCampanha(listaCsvBruta);

			var listaCampanhasAgrupadas = AgruparCampanhasEContarQuantidadeCliques(listaCsvNomeTratado);
		}

		private List<CampanhaModel> AgruparCampanhasEContarQuantidadeCliques(List<CsvModel> listaCsvNomeTratado)
		{
			return listaCsvNomeTratado.GroupBy(g => g.NomeCampanha)
				.Select(x => new CampanhaModel
				{
					NomeCampanha = x.Key,
					TotalCliques = x.Select(y => y.NomeCampanha.Equals(x.Key)).Count()
				})
				.OrderBy(y => y.NomeCampanha)
				.ToList();
		}

		private List<CsvModel> ConverteCsvParaListaDeCsvModel(TextReader csv)
		{
			var csvRowList = new List<CsvModel>();

			var parser = new CsvParser(csv);

			while (true)
			{
				var row = parser.Read();
				if (row == null)
				{
					break;
				}

				var splitRow = row[0].Split(';');

				var linha = new CsvModel()
				{
					NomeCampanha = splitRow[0],
					Ping = splitRow[1]
				};

				csvRowList.Add(linha);
			}

			return csvRowList;
		}

		private List<CsvModel> TratarNomeDaCampanha(List<CsvModel> csvRowList)
		{
			var listaCsvNomeTratado = new List<CsvModel>();

			foreach (var item in csvRowList)
			{
				var csv = new CsvModel();

				if (!item.NomeCampanha.Contains("CAMPAIGN"))
				{
					item.NomeCampanha = item.NomeCampanha.Split('_')[1];

					if (item.NomeCampanha.Contains("Retry"))
					{
						csv.NomeCampanha = item.NomeCampanha.Remove(item.NomeCampanha.Length - 6);
					}
					else
					{
						csv.NomeCampanha = item.NomeCampanha;
					}

					csv.Ping = item.Ping;

					listaCsvNomeTratado.Add(csv);
				}
			}

			return listaCsvNomeTratado;
		}
	}
}
