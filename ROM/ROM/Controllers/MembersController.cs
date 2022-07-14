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
            aMember.Categories = _context.Categories.ToList();

            if (ModelState.IsValid)
            {
                if (MemberIsExists(member.Code))
                {
                    ViewBag.UniqeChk = "Sorry, Member already exists! Code must be unique.";
                    return View(aMember);
                }

                _context.Members.Add(member);
                _context.SaveChanges();
                TempData["saveMsg"] = "The Member has been saved successfully.";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ValidationMsg = "All fields are required";
            }

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
                if (MemberIsExists(member.Code))
                {
                    ViewBag.UniqeChk = "Sorry, Member already exists! Code must be unique.";
                    return View(aMember);
                }
                
                _context.Members.Update(member);
                _context.SaveChanges();
                TempData["saveMsg"] = "The Member has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            
            return View(member);
        }

        public IActionResult Delete(int? id)
        {
            var member = _context.Members.Include(c=>c.Category).FirstOrDefault(d => d.Id == id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var member = _context.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            _context.Remove(member);
            _context.SaveChanges();
            TempData["saveMsg"] = "The Member has been deleted successfully.";
            return RedirectToAction(nameof(Index));
        }


        private bool MemberIsExists(string code)
        {
            return _context.Members.Any(c => c.Code == code);
        }

        private bool MemberIsExistsForUpdate(string code, int id)
        {
            List<Member> shortedMembers = new List<Member>();

            var members = _context.Members.Include(c => c.Category).ToList();
            var mem = _context.Members.FirstOrDefault(c => c.Id == id);

            foreach (var member in members)
            {
                if (member.Id != mem.Id)
                {
                    shortedMembers.Add(member);
                }
            }
            bool rs= shortedMembers.Any(c => c.Code == code);
            return rs;
        }
    }
}
