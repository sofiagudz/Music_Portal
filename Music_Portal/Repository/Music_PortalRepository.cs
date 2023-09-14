using Microsoft.EntityFrameworkCore;
using Music_Portal.Models;

namespace Music_Portal.Repository
{
    public class Music_PortalRepository : IRepository
    {
        public Music_PortalContext _context;

        public Music_PortalRepository(Music_PortalContext context)
        {
            _context = context;
        }

        //HomeController
        public async Task<List<User>> UsersToList()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> UsersToListIEnumerable()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<Song>> SongsToList()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<IEnumerable<Song>> SongsToListIEnumerable()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<List<Style>> StylesToList()
        {
            return await _context.Styles.ToListAsync();
        }

        public async Task<IEnumerable<Style>> StylesToListIEnumerable()
        {
            return await _context.Styles.ToListAsync();
        }

        public async Task<List<Singer>> SingersToList()
        {
            return await _context.Singers.ToListAsync();
        }

        public async Task<IEnumerable<Singer>> SingersToListIEnumerable()
        {
            return await _context.Singers.ToListAsync();
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task AddStyle(Style style)
        {
            await _context.Styles.AddAsync(style);
        }

        public async Task AddSinger(Singer singer)
        {
            await _context.Singers.AddAsync(singer);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> UsersCount()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<int> CheckingLoginCount(LoginModel login)
        {
            return await _context.Users.Where(a => a.Login == login.Login).CountAsync();
        }

        public async Task<User> CheckingLogin(LoginModel login)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Login == login.Login);
        }

        public async Task<User> FindUserById(string str)
        {
            return _context.Users.FirstOrDefault(a => a.Login == str);
        }

        public async Task<Style> FindStyleById(int id)
        {
            return _context.Styles.FirstOrDefault(a => a.Id == id);
        }

        public async Task<Singer> FindSingerById(int id)
        {
            return await _context.Singers.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Song> FindSongById(int id)
        {
            return await _context.Songs.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddSong(Song song)
        {
            await _context.Songs.AddAsync(song);
        }

		public async Task<User> FindUsers(int id)
		{
			return await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
		}

        public async Task<Style> FindStyle(int id)
        {
            return await _context.Styles.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void UpdateUser(User user)
		{
            _context.Update(user);
			//_context.Entry(user).State = EntityState.Modified;
		}

        public void UpdateStyle(Style style)
        {
            _context.Update(style);
        }

        public void UpdateSinger(Singer singer)
        {
            _context.Update(singer);
        }

        public void UpdateSong(Song song)
        {
            _context.Update(song);
        }

        public async Task DeleteUser(int id)
		{
			User? c = await _context.Users.FindAsync(id);
			if (c != null)
				_context.Users.Remove(c);
		}

        public async Task DeleteStyle(int id)
        {
            Style? c = await _context.Styles.FindAsync(id);
            if (c != null)
                _context.Styles.Remove(c);
        }

        public async Task DeleteSinger(int id)
        {
            Singer? c = await _context.Singers.FindAsync(id);
            if (c != null)
                _context.Singers.Remove(c);
        }

		public async Task DeleteSong(int id)
		{
			Song? c = await _context.Songs.FindAsync(id);
			if (c != null)
				_context.Songs.Remove(c);
		}
	}
}
