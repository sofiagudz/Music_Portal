using Music_Portal.Models;

namespace Music_Portal.Repository
{
    public interface IRepository
    {
        //HomeController
        Task<List<User>> UsersToList();
        Task<IEnumerable<User>> UsersToListIEnumerable();
        Task<List<Song>> SongsToList();
        Task<IEnumerable<Song>> SongsToListIEnumerable();
        Task<List<Style>> StylesToList();
        Task<IEnumerable<Style>> StylesToListIEnumerable();
        Task AddUser(User user);
        Task Save();
        Task<int> UsersCount();
        Task<int> CheckingLoginCount(LoginModel login);
        Task<User> CheckingLogin(LoginModel login);
        Task<User> FindUserById(string str);
        Task<Style> FindStyleById(int id);
        Task<Song> FindSongById(int id);
        Task AddSong(Song song);
        Task<User> FindUsers(int id);
        void UpdateUser(User user);
        void UpdateSong(Song song);
        Task DeleteUser(int id);
        Task DeleteSong(int id);

		//AdminController
		Task AddStyle(Style style);
        void UpdateStyle(Style style);
        Task<Style> FindStyle(int id);
        Task DeleteStyle(int id);
        Task<List<Singer>> SingersToList();
        Task<IEnumerable<Singer>> SingersToListIEnumerable();
        Task AddSinger(Singer singer);
        Task<Singer> FindSingerById(int id);
        void UpdateSinger(Singer singer);
        Task DeleteSinger(int id);
    }
}
