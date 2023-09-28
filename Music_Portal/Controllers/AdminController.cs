using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_Portal.Models;
using Music_Portal.Repository;

namespace Music_Portal.Controllers
{
    public class AdminController : Controller
    {
        IRepository repo;

        public AdminController(IRepository r)
        {
            repo = r;
        }

        public async Task<IActionResult> AddStyle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStyle(Style style)
        {
            try
            {
                await repo.AddStyle(style);
                await repo.Save();
                return RedirectToAction(nameof(StylesToList));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(StylesToList));
            }
        }

        public async Task<ActionResult> EditStyle(int? id)
        {
            if (id == null || await repo.StylesToList() == null)
            {
                return NotFound();
            }
            var style = await repo.FindStyleById((int)id);
            if (style == null)
            {
                return NotFound();
            }
            return View(style);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStyle(int id, Style style)
        {
            if (id != style.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateStyle(style);
                    await repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StyleExists(style.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(StylesToList));
            }
            return RedirectToAction(nameof(StylesToList));
        }

        private async Task<bool> StyleExists(int id)
        {
            List<Style> list = await repo.StylesToList();
            return (list?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> DeleteStyle(int? id)
        {
            if (id == null || await repo.StylesToList() == null)
            {
                return NotFound();
            }
            var style = await repo.FindStyle((int)id);
            if (style == null)
            {
                return NotFound();
            }
            return View(style);
        }

        [HttpPost, ActionName("DeleteStyle")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStyleConfirmed(int id)
        {
            if (await repo.StylesToList() == null)
            {
                return Problem("Entity set 'Music_PortalContext.Styles' is null.");
            }
            var student = await repo.FindStyle(id);
            if (student != null)
            {
                await repo.DeleteStyle(id);
            }
            await repo.Save();
            return RedirectToAction(nameof(StylesToList));
        }

        public async Task<IActionResult> AddSinger()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSinger(Singer singer)
        {
            try
            {
                await repo.AddSinger(singer);
                await repo.Save();
                return RedirectToAction(nameof(SingersToList));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(SingersToList));
            }
        }

        public async Task<ActionResult> EditSinger(int? id)
        {
            if (id == null || await repo.SingersToList() == null)
            {
                return NotFound();
            }
            var singer = await repo.FindSingerById((int)id);
            if (singer == null)
            {
                return NotFound();
            }
            return View(singer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSinger(int id, Singer singer)
        {
            if (id != singer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateSinger(singer);
                    await repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SingerExists(singer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SingersToList));
            }
            return RedirectToAction(nameof(SingersToList));
        }

        public async Task<IActionResult> DeleteSinger(int? id)
        {
            if (id == null || await repo.SingersToList() == null)
            {
                return NotFound();
            }
            var singer = await repo.FindSingerById((int)id);
            if (singer == null)
            {
                return NotFound();
            }
            return View(singer);
        }

        [HttpPost, ActionName("DeleteSinger")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSingerConfirmed(int id)
        {
            if (await repo.SingersToList() == null)
            {
                return Problem("Entity set 'Music_PortalContext.Singers' is null.");
            }
            var singer = await repo.FindSingerById(id);
            if (singer != null)
            {
                await repo.DeleteSinger(id);
            }
            await repo.Save();
            return RedirectToAction(nameof(SingersToList));
        }

        private async Task<bool> SingerExists(int id)
        {
            List<Singer> list = await repo.SingersToList();
            return (list?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<ActionResult> StylesToList()
        {
            return await repo.StylesToList() != null ?
                View(await repo.StylesToListIEnumerable()) :
                Problem("Entity set 'Music_PortalContext.Styles' is null");
        }

        public async Task<ActionResult> SingersToList()
        {
            return await repo.SingersToList() != null ?
                View(await repo.SingersToListIEnumerable()) :
                Problem("Entity set 'Music_PortalContext.Singers' is null");
        }
    }
}
