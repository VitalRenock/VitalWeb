using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VitalWeb.DAL;
using VitalWeb.Models;

namespace VitalWeb.Controllers
{
    public class PostController : Controller
    {

        #region DB Context

        private readonly VitalDBContext _context;

        public PostController(VitalDBContext context)
        {
            _context = context;
        }

        #endregion

        #region Index

        // GET: Post
        public async Task<IActionResult> Index()
        {
            return View(await PostDAL.ListAll(_context));
        }
            
        #endregion
        
        #region Details

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            Post post = await PostDAL.GetById(_context, id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        #endregion

        #region Create

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["TagID"] = new SelectList(_context.Tags, "TagID", "Name");
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostID,Title,Content,PostDate,TagID")] Post post)
        {
            if (ModelState.IsValid)
            {
                await PostDAL.AddAsync(_context, post);
                await PostDAL.SaveAsync(_context);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TagID"] = new SelectList(_context.Tags, "TagID", "Name", post.TagID);
            return View(post);
        }
            
        #endregion
        
        #region Edit

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var post = await PostDAL.GetById(_context, id);

            if (post == null)
                return NotFound();

            ViewData["TagID"] = new SelectList(_context.Tags, "TagID", "Name", post.TagID);
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostID,Title,Content,PostDate,TagID")] Post post)
        {
            if (id != post.PostID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    PostDAL.Update(_context, post);
                    await PostDAL.SaveAsync(_context);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["TagID"] = new SelectList(_context.Tags, "TagID", "Name", post.TagID);
            return View(post);
        }
            
        #endregion

        #region Delete

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var post = await PostDAL.GetById(_context, id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await PostDAL.RemoveByIdAsync(_context, id);
            await PostDAL.SaveAsync(_context);

            return RedirectToAction(nameof(Index));
        }
            
        #endregion
        
        #region Exists

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostID == id);
        }
            
        #endregion

    }
}
