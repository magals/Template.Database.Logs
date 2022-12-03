namespace Template.Database.Logs.DbContexts.Base.Models
{
	public class LogMessageEntity : Entity
	{
		[Required]
		public DateTimeOffset DateTimeOffset { get; set; }

		[Required]
		public LogLevel LogLevel { get; set; }

		[Required]
		[StringLength(500)]
		public string Message { get; set; } = string.Empty;

		[Required]
		public int ThreadId { get; set; }
	}
}
