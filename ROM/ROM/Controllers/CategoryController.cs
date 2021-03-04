using Microsoft.AspNetCore.Mvc;
using ROM.DBContext;
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
            return View();
        }

        public IActionResult Save()
        {
            return View();
        }
    }
}
