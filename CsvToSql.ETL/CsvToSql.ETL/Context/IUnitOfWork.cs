using System;
using System.Collections.Generic;
using System.Text;

namespace CsvToSql.ETL.Context
{
	public interface IUnitOfWork
	{
		ICommandStack CommandStack { get; }
	}
}
