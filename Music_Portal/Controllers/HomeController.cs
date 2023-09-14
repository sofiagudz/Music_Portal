using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_Portal.Models;
using Music_Portal.Repository;
using System.Diagnostics;

namespace Music_Portal.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;
        IWebHostEnvironment _appEnvironment;

        public HomeController(IRepository r, IWebHostEnvironment appEnvironment)
        {
            repo = r;
            _appEnvironment = appEnvironment;
        }

        public async Task<ActionResult> Index()
        {
            return await repo.SongsToList() != null ?
                View(await repo.SongsToListIEnumerable()) :
                Problem("Entity set 'Music_PortalContext.Songs' is null");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationModel reg)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Name = reg.Name;
                user.Surname = reg.Surname;
                user.Login = reg.Login;
                user.Email = reg.Email;
                if (reg.Login == "admin")
                {
                    user.AccessLevel = 1;
                }
                else
                {
                    user.AccessLevel = 0;
                }
                user.Password = reg.Password;
                await repo.AddUser(user);
                await repo.Save();
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel _login)
        {
            if (ModelState.IsValid)
            {
                if (repo.UsersCount() == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(_login);
                }
                var user = await repo.CheckingLogin(_login);
                if (repo.CheckingLoginCount(_login) == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(_login);
                }
                HttpContext.Session.SetString("Login", user.Login);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> AddSong()
        {
            ViewData["StyleId"] = new SelectList(await repo.StylesToList(), "Id", "Name");
            ViewData["SingerId"] = new SelectList(await repo.SingersToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSong([Bind("Id,Name,Album,ReleaseYear,Video,Publisher,StyleId,SingerId")] Song song, IFormFile uploadedVideo)
        {
            try
            {
                if(uploadedVideo != null)
                {
                    string path = "/uploadedFiles/" + uploadedVideo.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedVideo.CopyToAsync(fileStream); // копируем файл в поток
                    }
                    string login = HttpContext.Session.GetString("Login");
                    var user = await repo.FindUserById(login);

                    song.Publisher = user;
                    song.Video = path;
                    await repo.AddSong(song);
                    await repo.Save();
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> EditSong(int? id)
        {
            if (id == null || repo.SongsToList == null)
            {
                return NotFound();
            }
            var song = await repo.FindSongById((int)id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["StyleId"] = new SelectList(await repo.StylesToList(), "Id", "Name");
            ViewData["SingerId"] = new SelectList(await repo.SingersToList(), "Id", "Name");
            return View(song);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSong(int id, Song song, IFormFile uploadedVideo)
        {
            if (id != song.Id)
            {
                return NotFound();
            }
                try
                {
                    if (uploadedVideo != null)
                    {
                        string path = "/uploadedFiles/" + uploadedVideo.FileName;
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedVideo.CopyToAsync(fileStream);
                        }
                    song.Video = path;
                    repo.UpdateSong(song);
                    await repo.Save();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await SongExists(song.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            return View(nameof(Index));
        }

		public async Task<IActionResult> DeleteSong(int? id)
		{
			if (id == null || repo.SongsToList() == null)
			{
				return NotFound();
			}
			var song = await repo.FindSongById((int)id);
			if (song == null)
			{
				return NotFound();
			}
			return View(song);
		}

		//POST: Delete
		[HttpPost, ActionName("DeleteSong")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteSongConfirmed(int id)
		{
			if (repo.SongsToList() == null)
			{
				return Problem("Entity set 'Music_PortalContext.Songs' is null");
			}
			var song = await repo.FindSongById(id);
			if (song != null)
			{
				await repo.DeleteSong(id);
			}
			await repo.Save();
			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> SongExists(int id)
        {
            List<Song> list = await repo.SongsToList();
            return (list?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || await repo.UsersToList() == null)
            {
                return NotFound();
            }
            var users = await repo.FindUsers((int)id);
            if(users == null) 
            {
                return NotFound();
            }
			return View(users);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
			if (ModelState.IsValid)
			{
				try
				{
					repo.UpdateUser(user);
					await repo.Save();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!await StudentExists(user.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(UsersList));
			}
            return RedirectToAction(nameof(UsersList));
        }

		private async Task<bool> StudentExists(int id)
		{
			List<User> list = await repo.UsersToList();
			return (list?.Any(e => e.Id == id)).GetValueOrDefault();
		}

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || await repo.UsersToList() == null)
            {
                return NotFound();
            }
            var user = await repo.FindUsers((int)id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(await repo.UsersToList() == null)
            {
                return Problem("Entity set 'Music_PortalContext.Users' is null.");
            }
            var student = await repo.FindUsers(id);
            if (student != null)
            {
                await repo.DeleteUser(id);
            }
            await repo.Save();
            return RedirectToAction(nameof(UsersList));
        }

        //все участиники
		public async Task<ActionResult> UsersList()
		{
            return await repo.UsersToList() != null ?
                View(await repo.UsersToListIEnumerable()) :
                Problem("Entity set 'Music_PortalContext.Users' is null");
		}
	}
}