namespace CompanyFinderAPI.ViewModels

{
    public class CompanyViewModel
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int WatchListId { get; set; }
        public List<int> SelectedCompanyIds { get; set; } = new List<int>();
    }
}
