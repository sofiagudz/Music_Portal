namespace Music_Portal.Models
{
	public class SortViewModelStyle
	{
		public SortStateStyle NameSort { get; set; }
		public SortStateStyle Current { get; set; }
		public bool Up { get; set; }

		public SortViewModelStyle(SortStateStyle sortOrder)
		{
			NameSort = SortStateStyle.NameAsc;

			NameSort = sortOrder == SortStateStyle.NameAsc ? SortStateStyle.NameDesc : SortStateStyle.NameAsc;
			Current = sortOrder;
		}
	}
}
