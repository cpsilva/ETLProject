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
			var listaCsvBruta = CsvParaListaDeCsvRow(csv);

			var listaCsvNomeTratado = TratarNomeDaCampanha(listaCsvBruta);

			var listaCampanhasAgrupadas = AgruparCampanhasEContarQuantidadeCliques(listaCsvNomeTratado);
		}

		private object AgruparCampanhasEContarQuantidadeCliques(List<CsvRow> listaCsvNomeTratado)
		{
			IEnumerable<CsvRow> teste;

			teste = listaCsvNomeTratado;

			var one = teste.GroupBy(g => g.NomeCampanha)
				.Select(gpr => gpr.Key)
				.ToList();

			Console.WriteLine(one);
			Console.ReadKey();

			throw new NotImplementedException();
		}

		private List<CsvRow> CsvParaListaDeCsvRow(TextReader csv)
		{
			var csvRowList = new List<CsvRow>();

			var parser = new CsvParser(csv);

			while (true)
			{
				var row = parser.Read();
				if (row == null)
				{
					break;
				}

				var splitRow = row[0].Split(';');

				var linha = new CsvRow()
				{
					NomeCampanha = splitRow[0],
					Ping = splitRow[1]
				};

				csvRowList.Add(linha);
			}

			return csvRowList;
		}

		private List<CsvRow> TratarNomeDaCampanha(List<CsvRow> csvRowList)
		{
			var listaCsvNomeTratado = new List<CsvRow>();

			foreach (var item in csvRowList)
			{
				var csv = new CsvRow();

				if (!item.NomeCampanha.Contains("CAMPAIGN"))
				{
					csv.NomeCampanha = item.NomeCampanha.Split('_')[1];
					csv.Ping = item.Ping;

					listaCsvNomeTratado.Add(csv);
				}
			}

			return listaCsvNomeTratado;
		}
	}
}
