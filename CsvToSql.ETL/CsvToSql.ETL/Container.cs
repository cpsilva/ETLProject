using System;
using System.Collections.Generic;
using System.Text;
using CsvToSql.ETL.AmazonService;
using CsvToSql.ETL.CsvService;
using CsvToSql.ETL.EtlService;
using CsvToSql.ETL.FtpService;
using CsvToSql.ETL.SqlService;
using Microsoft.Extensions.DependencyInjection;

namespace CsvToSql.ETL
{
	public class Container
	{
		private static IServiceCollection _services;
		private static IServiceProvider _serviceProvider;

		public static T GetService<T>()
		{
			if (_services == null)
			{
				_services = RegisterServices();
			}

			if (_serviceProvider == null)
			{
				_serviceProvider = _services.BuildServiceProvider();
			}

			return _serviceProvider.GetService<T>();
		}

		public static IServiceCollection RegisterServices(IServiceCollection services = null)
		{
			_services = services ?? new ServiceCollection();

			//ETLProject Services
			_services.AddScoped<IEtlService, EtlService.EtlService>();
			_services.AddScoped<IAmazonService, AmazonService.AmazonService>();
			_services.AddScoped<ICsvService, CsvService.CsvService>();
			_services.AddScoped<IFtpService, FtpService.FtpService>();
			_services.AddScoped<ISqlService, SqlService.SqlService>();
			_services.BuildServiceProvider();

			return services;
		}
	}
}
