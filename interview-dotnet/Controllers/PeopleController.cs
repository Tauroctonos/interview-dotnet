using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using interview_dotnet;
using System.IO;

namespace interview_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DBContext _context;

        public PeopleController(DBContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<IActionResult> PutPerson(string firstName, string lastName, string phone)
        {
            var person = new Person { FirstName = firstName, LastName = lastName, Phone = phone, Id = Guid.NewGuid()};
            _context.Add(person);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
		public async Task<IActionResult> ProcessFile(IFormFile file)
        {
			if (file.Length > 0)
			{
				var allLines = "";

				using (var stream = file.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    var line = "";
                    
                    do
                    {
                        line = await reader.ReadLineAsync();
                        allLines += line + "\n";
                        Console.WriteLine(line);
                    } while (line != null);
                    
                }
				return Content(allLines);
			}
            return NoContent();
		}


	}
}
