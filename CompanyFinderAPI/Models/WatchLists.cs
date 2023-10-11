using System.ComponentModel.DataAnnotations;

namespace CompanyFinderAPI.Models
{
    public class WatchLists
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Sector { get; set; }
        public string? Industry { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}
