using System.ComponentModel.DataAnnotations;

namespace interview_dotnet
{
	public class Person
	{
		[Key] public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
	}
}
