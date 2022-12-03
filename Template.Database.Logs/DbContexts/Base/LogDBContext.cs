

namespace Template.Database.Logs.DbContexts.Base
{

	public class LogDBContext : DbContext
	{
		public DbSet<LogMessageEntity>? LogMessageEntity { get; set; }

		public LogDBContext(DbContextOptions<LogDBContext> options)
				: base(options)
		{
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

	}
}
