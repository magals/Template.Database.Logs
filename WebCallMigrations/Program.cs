using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Template.Database.Logs.DbContexts.SQLite;
using Template.Database.Logs.DbContexts.MSSQL;
namespace WebCallMigrations
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var dc = builder.Configuration.GetSection("ConnectionStrings:SQLiteConnection_Logs")?.Value ?? string.Empty;//
			var mssql = builder.Configuration.GetSection("ConnectionStrings:MSSQLConnection_Logs")?.Value ?? string.Empty;
			builder.Services.AddDbContext<LogDBContext_SQLite>();
			//dotnet ef database update --startup-project .\WebCallMigrations.csproj -c LogDBContext_SQLite
			builder.Services.AddDbContext<LogDBContext_MSSQL>(options => { options.UseSqlServer(mssql); });
			//dotnet ef database update --startup-project .\WebCallMigrations.csproj -c LogDBContext_MSSQL
			var app = builder.Build().MigrateDatabase<LogDBContext_SQLite>();

			app.MapGet("/", () => "Hello World!");

			app.Run();
		}
	}
	public static class Extenstion
	{
		public static WebApplication MigrateDatabase<T>(this WebApplication webHost) where T : DbContext
		{
			using (var scope = webHost.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var db = services.GetRequiredService<T>();
					db.Database.Migrate();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while migrating the database.");
				}
			}
			return webHost;
		}
	}
}