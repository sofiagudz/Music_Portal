namespace Music_Portal.Models
{
    public class SortViewModelUser
    {
        public SortStateUser NameSort { get; set; }
        public SortStateUser SurnameSort { get; set; }
        public SortStateUser LoginSort { get; set; }
        public SortStateUser EmailSort { get; set; }
        public SortStateUser AccessLevelSort { get; set; }
        public SortStateUser Current { get; set; }
        public bool Up { get; set; }

        public SortViewModelUser(SortStateUser sortOrder)
        {
            NameSort = SortStateUser.NameAsc;
            SurnameSort = SortStateUser.SurnameAsc;
            LoginSort = SortStateUser.LoginAsc;
            EmailSort = SortStateUser.EmailAsc;
            AccessLevelSort = SortStateUser.AccessLevelAsc;

            NameSort = sortOrder == SortStateUser.NameAsc ? SortStateUser.NameDesc : SortStateUser.NameAsc;
            SurnameSort = sortOrder == SortStateUser.SurnameAsc ? SortStateUser.SurnameDesc : SortStateUser.SurnameAsc;
            LoginSort = sortOrder == SortStateUser.LoginAsc ? SortStateUser.LoginDesc : SortStateUser.LoginAsc;
            EmailSort = sortOrder == SortStateUser.EmailAsc ? SortStateUser.EmailDesc : SortStateUser.EmailAsc;
            AccessLevelSort = sortOrder == SortStateUser.AccessLevelAsc ? SortStateUser.AccessLevelDesc : SortStateUser.AccessLevelAsc;
            Current = sortOrder;
        }
    }
}
