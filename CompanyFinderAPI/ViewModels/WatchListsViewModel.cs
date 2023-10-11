using System.ComponentModel.DataAnnotations;

namespace CompanyFinderAPI.ViewModels
{
    public class WatchListsViewModel
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string? Name { get; set; }

        public string? Description { get; set; }
        public string? Sector { get; set; }
        public string? Industry { get; set; }
        public List<int>? SelectedCompanyIds { get; set; }
        public int WishListId { get; set; }

    }
}
