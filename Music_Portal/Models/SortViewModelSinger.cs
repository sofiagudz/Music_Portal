namespace Music_Portal.Models
{
	public class SortViewModelSinger
	{
		public SortStateSinger NameSort { get; set; }
		public SortStateSinger Current { get; set; }
		public bool Up { get; set; }

		public SortViewModelSinger(SortStateSinger sortOrder)
		{
			NameSort = SortStateSinger.NameAsc;

			NameSort = sortOrder == SortStateSinger.NameAsc ? SortStateSinger.NameDesc : SortStateSinger.NameAsc;
			Current = sortOrder;
		}
	}
}
