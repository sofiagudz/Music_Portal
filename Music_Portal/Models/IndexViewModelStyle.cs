namespace Music_Portal.Models
{
	public class IndexViewModelStyle
	{
		public IEnumerable<Style> Styles { get; }
		public PageViewModelStyle PageViewModel { get; }
		public SortViewModelStyle SortViewModel { get; }
		public IndexViewModelStyle(IEnumerable<Style> styles, PageViewModelStyle viewModel, SortViewModelStyle sortViewModel)
		{
			Styles = styles;
			PageViewModel = viewModel;
			SortViewModel = sortViewModel;
		}
	}
}
