using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTest.Data;
using RazorPagesTest.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace RazorPagesTest.Pages.Images
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTest.Data.RazorPagesTestContext _context;
        private IWebHostEnvironment _environment;
        private string webRootPath;

        public DeleteModel(RazorPagesTest.Data.RazorPagesTestContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Image Image { get; set; }
        public string ImagePath { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Image = await _context.Image.FirstOrDefaultAsync(m => m.Id == id);

            if (Image == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Image = await _context.Image.FindAsync(id);

            //delete file from file system
            if (Image != null)
            {
                _context.Image.Remove(Image);
                await _context.SaveChangesAsync();
                webRootPath = _environment.WebRootPath;
                ImagePath = webRootPath + "/Uploads/" + Image.Title;
                System.IO.File.Delete(ImagePath);
            }

            return RedirectToPage("./Index");
        }
    }
}
