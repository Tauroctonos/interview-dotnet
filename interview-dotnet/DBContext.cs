using Microsoft.EntityFrameworkCore;

namespace interview_dotnet
{
	public class DBContext: DbContext
	{ 
		public DBContext(DbContextOptions<DBContext> options)
		: base(options)
		{
		}

		public DbSet<Person> Entries { get; set; } = null;
	}
}
