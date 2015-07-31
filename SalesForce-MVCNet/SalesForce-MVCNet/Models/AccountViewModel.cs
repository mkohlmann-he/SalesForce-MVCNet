using System.ComponentModel.DataAnnotations;


// Salesforce specific "Salesforce Account" record model
namespace WebApplication9.Models
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
