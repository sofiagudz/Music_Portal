namespace Music_Portal.Models
{
    public class SortViewModelSong
    {
        public SortState NameSort { get; set; }
        public SortState AlbumSort { get; set; }
        public SortState SingerSort { get; set; }
        public SortState StyleSort { get; set; }
        public SortState YearSort { get; set; }
        public SortState Current { get; set; }
        public bool Up { get; set; }

        public SortViewModelSong(SortState sortOrder)
        {
            NameSort = SortState.NameAsc;
            AlbumSort = SortState.AlbumAsc;
            SingerSort = SortState.SingerAsc;
            StyleSort = SortState.StyleAsc;
            YearSort = SortState.YearAsc;

            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            AlbumSort = sortOrder == SortState.AlbumAsc ? SortState.AlbumDesc : SortState.AlbumAsc;
            SingerSort = sortOrder == SortState.SingerAsc ? SortState.SingerDesc : SortState.SingerAsc;
            StyleSort = sortOrder == SortState.StyleAsc ? SortState.StyleDesc : SortState.StyleAsc;
            YearSort = sortOrder == SortState.YearAsc ? SortState.YearDesc : SortState.YearAsc;
            Current = sortOrder;
        }
    }
}
