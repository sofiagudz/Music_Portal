namespace Music_Portal.Models
{
    public class IndexViewModelSong
    {
        public IEnumerable<Song> Songs { get; }
        public PageViewModelSong PageViewModel { get; }
        public SortViewModelSong SortViewModel { get; }
        public IndexViewModelSong(IEnumerable<Song> songs, PageViewModelSong viewModel, SortViewModelSong sortViewModel)
        {
            Songs = songs;
            PageViewModel = viewModel;
            SortViewModel = sortViewModel;
        }
    }
}
