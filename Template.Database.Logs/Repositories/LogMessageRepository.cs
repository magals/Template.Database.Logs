namespace Template.Database.Logs.Repositories
{
	public class LogMessageRepository
	{
		private readonly LogDBContext _context;
		public LogMessageRepository(LogDBContext context)
		{
			_context = context;
		}

		public void Create(LogMessageEntity customer)
		{
			ArgumentNullException.ThrowIfNull(_context.LogMessageEntity);
		
			_context.LogMessageEntity.Add(customer);
			_context.SaveChanges();
		}
	}
}
