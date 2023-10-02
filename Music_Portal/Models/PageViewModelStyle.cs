namespace Music_Portal.Models
{
	public class PageViewModelStyle
	{
		public int PageNumber { get; }
		public int TotalPages { get; }
		public bool HasPreviousPage => PageNumber > 1;
		public bool HasNextPage => PageNumber < TotalPages;

		public PageViewModelStyle(int count, int pageNumber, int pageSize)
		{
			PageNumber = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
		}
	}
}
