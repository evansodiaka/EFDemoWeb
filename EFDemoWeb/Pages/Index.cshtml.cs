using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFDemoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _logger = logger;
            _db= db;
        }

        public void OnGet()
        {

        }
        private void LoadSampleData() {             // Sample data loading logic
            // This could be a method that populates the database with initial data
            // for testing or demonstration purposes.

            if ( _db.People.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("generated.json");
                var people = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(file);
                _db.AddRange(people);
                _db.SaveChanges();  
            }

        }   
    }
}
