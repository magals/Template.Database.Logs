using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Database.Logs.DbContexts.SQLite
{
	public class LogDBContext_SQLite: LogDBContext
	{
		public LogDBContext_SQLite(IConfiguration configuration) : base(configuration)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite(Configuration.GetConnectionString("SQLiteConnection_Logs"));
		}
	}
}
