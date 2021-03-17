using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROM.DBContext;
using ROM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Controllers
{
    public class MembersController : Controller
    {
        Member aMember = new Member();
        private readonly ROMDatabaseContext _context;
        public MembersController(ROMDatabaseContext romDbContext)
        {
            _context = romDbContext;
        }
        public IActionResult Index()
        {
            return View(_context.Members.Include(c => c.Category).ToList());
        }

        public IActionResult Add()
        {
            aMember.Categories = _context.Categories.ToList();
            return View(aMember);
        }

        [HttpPost]
        public IActionResult Add(Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                _context.SaveChanges();
                //ViewBag.SuccessMsg = "Save Success.";

                return RedirectToAction(nameof(Index));
            }
            //else
            //{
            //    ViewBag.ErrorMsg = "Save Failed!";
            //}

            aMember.Categories = _context.Categories.ToList();
            return View(aMember);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = _context.Members.Find(id);
            var categories = _context.Categories.ToList();
            if (members == null)
            {
                return NotFound();
            }

            ViewBag.Category = new SelectList(categories, "Id", "Name");
            return View(members);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            var categories = _context.Categories.ToList();
            ViewBag.Category = new SelectList(categories, "Id", "Name");

            if (ModelState.IsValid)
            {
                _context.Members.Update(member);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            return View(member);
        }

        public IActionResult Delete(int? id)
        {
            var member = _context.Members.FirstOrDefault(d => d.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
    }
}
