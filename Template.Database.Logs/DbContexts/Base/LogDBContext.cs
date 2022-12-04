

using Microsoft.Extensions.Configuration;
using System.Reflection;
using Template.Database.Logs.DbContexts.MSSQL;

namespace Template.Database.Logs.DbContexts.Base
{

	public abstract class LogDBContext : DbContext
	{
		public DbSet<LogMessageEntity>? LogMessageEntity { get; set; }

		protected readonly IConfiguration Configuration;

		protected LogDBContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<LogMessageEntity>(entity =>
			{
				entity.Property(e => e.LogLevel).HasConversion<string>();
				entity.HasData(new LogMessageEntity
				{
					Id = 1,
					LogLevel = LogLevel.Information,
					DateTimeOffset = DateTimeOffset.UtcNow,
					Message = "First Message",
					ThreadId = Thread.CurrentThread.ManagedThreadId
				});
			});
		}

		//protected void ApplyConfiguration(ModelBuilder modelBuilder, string[] namespaces)
		//{
		//	var methodInfo = (typeof(ModelBuilder).GetMethods()).Single((e =>
		//			e.Name == "ApplyConfiguration" &&
		//			e.ContainsGenericParameters &&
		//			e.GetParameters().SingleOrDefault()?.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

		//	foreach (var configType in typeof(LogDBContext_MSSQL).GetTypeInfo().Assembly.GetTypes()

		//			.Where(t => t.Namespace != null &&
		//									namespaces.Any(n => n == t.Namespace) &&
		//									t.GetInterfaces().Any(i => i.IsGenericType &&
		//																						 i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))))
		//	{
		//		var type = configType.GetInterfaces().First();
		//		methodInfo.MakeGenericMethod(type.GenericTypeArguments[0]).Invoke(modelBuilder, new[]
		//		{
		//				Activator.CreateInstance(configType)
		//		});
		//	}
		//}

	}
}
