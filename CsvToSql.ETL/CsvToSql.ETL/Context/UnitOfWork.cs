using System;
using System.Collections.Generic;
using System.Text;

namespace CsvToSql.ETL.Context
{
	public class UnitOfWork : IUnitOfWork
	{
		public ICommandStack CommandStack { get; }

		public UnitOfWork(ICommandStack commandStack)
		{
			CommandStack = commandStack;
		}
	}
}
