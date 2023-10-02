namespace Music_Portal.Models
{
    public class PageViewModelUser
    {
        public int PageNumber { get; }
        public int TotalPages { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PageViewModelUser(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
