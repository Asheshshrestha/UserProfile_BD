using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileDisplay.Models;
using ProfileDisplay.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ProfileDisplay.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserProfileContext _context;

        public ProfileController(UserProfileContext context)
        {
           _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserProfile.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,FirstName,LastName,Degree,University,JobPost,Company,Experience")] UserProfile profile, IFormFile CoverImage , IFormFile ProfileImage)
        {
            if (ModelState.IsValid)
            {
                if(ProfileImage !=null && ProfileImage.Length >0)
                {
                    var fileName = Path.GetFileName(ProfileImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\items", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await ProfileImage.CopyToAsync(fileSteam);
                    }
                    profile.ProfileImage = fileName;
                }
                if (CoverImage != null && CoverImage.Length > 0)
                {
                    var fileName = Path.GetFileName(CoverImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\items", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await CoverImage.CopyToAsync(fileSteam);
                    }
                    profile.CoverImage = fileName;
                }
                _context.Add(profile);
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));

            }
            return View(profile);
        }
        
        public async Task<IActionResult> Details(string username)
        {
            if (username == null)
            {
                return NotFound();
            }
            var person = await _context.UserProfile
                .FirstOrDefaultAsync ( p => p.UserName == username);
            if(person == null)
            {
                return NotFound();
            }
            return View(person);


        }
        [Route("Profile/Edit/{username}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string username, [Bind("UserName,FirstName,LastName,Degree,University,JobPost,Company,Experience")] UserProfile profile, IFormFile CoverImage, IFormFile ProfileImage)
        {
            if (username != profile.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ProfileImage != null && ProfileImage.Length > 0)
                {
                    var fileName = Path.GetFileName(ProfileImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\items", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await ProfileImage.CopyToAsync(fileSteam);
                    }
                    profile.ProfileImage = fileName;
                }
                if (CoverImage != null && CoverImage.Length > 0)
                {
                    var fileName = Path.GetFileName(CoverImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\items", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await CoverImage.CopyToAsync(fileSteam);
                    }
                    profile.CoverImage = fileName;
                }
                
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(profile.UserName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profile);
        }
        private bool UserProfileExists(string username)
        {
            return _context.UserProfile.Any(e => e.UserName == username);
        }
        [Route("Profile/Edit/{username}")]
        public async Task<IActionResult> Edit(string username)
        {
            if (username == null)
            {
                return NotFound();
            }

            var person = await _context.UserProfile.FindAsync(username);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }



    }
}