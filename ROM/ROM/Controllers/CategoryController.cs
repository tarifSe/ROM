using Microsoft.AspNetCore.Mvc;
using ROM.DBContext;
using ROM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ROMDatabaseContext _context;
        public CategoryController(ROMDatabaseContext rOMDatabaseContext)
        {
            _context = rOMDatabaseContext;
        }

        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(category);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
