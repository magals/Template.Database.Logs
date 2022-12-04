using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Database.Logs.DbContexts.MSSQL
{
	public class LogDBContext_MSSQL : LogDBContext
	{
		public LogDBContext_MSSQL(IConfiguration configuration) : base(configuration)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnection_Logs"));
		}

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	var namespaces = new[] { "Template.Database.Logs.DbContexts.MSSQL" };
		//	ApplyConfiguration(modelBuilder, namespaces);
		//}
	}
}
