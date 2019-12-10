using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using SpiceWeb.Data;
using SpiceWeb.Models;

namespace SpiceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

      

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task <IActionResult> Index()
        {
            return View(await _db.Category.OrderBy(p=>p.Name).ToListAsync());
        }

        //Get for crate 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)

        { 
          if (ModelState.IsValid)

            {
                var doesCategoryExists = _db.Category.Any(p => p.Name == category.Name);
                if (doesCategoryExists)
                {
                    ViewBag.ErrorMessage = "! Category Already Exists ";

                }

                else
                {
                    _db.Category.Add(category);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            
                return View(category);
            
        }
        //get
         public async Task<IActionResult>  Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var category = await _db.Category.FindAsync(id);
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _db.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }       
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                var category = await _db.Category.FindAsync(id);
                _db.Category.Remove(category);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        //get  Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _db.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

    }
}