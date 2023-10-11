namespace CompanyFinderAPI.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        // Foreign Key for WatchList
        public int? WatchListId { get; set; }
        public WatchLists WatchList { get; set; }
    }
}
