namespace Music_Portal.Models
{
    public class IndexViewModelUser
    {
        public IEnumerable<User> Users { get; }
        public PageViewModelUser PageViewModel { get; }
        public SortViewModelUser SortViewModel { get; }
        public IndexViewModelUser(IEnumerable<User> users, PageViewModelUser viewModel, SortViewModelUser sortViewModel)
        {
            Users = users;
            PageViewModel = viewModel;
            SortViewModel = sortViewModel;
        }
    }
}
