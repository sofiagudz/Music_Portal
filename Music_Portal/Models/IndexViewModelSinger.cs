namespace Music_Portal.Models
{
	public class IndexViewModelSinger
	{
		public IEnumerable<Singer> Singers { get; }
		public PageViewModelSinger PageViewModel { get; }
		public SortViewModelSinger SortViewModel { get; }
		public IndexViewModelSinger(IEnumerable<Singer> singers, PageViewModelSinger viewModel, SortViewModelSinger sortViewModel)
		{
			Singers = singers;
			PageViewModel = viewModel;
			SortViewModel = sortViewModel;
		}
	}
}
