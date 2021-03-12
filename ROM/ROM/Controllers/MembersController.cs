﻿using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction(nameof(Index));
            }

            aMember.Categories = _context.Categories.ToList();
            return View(aMember);
        }
    }
}
