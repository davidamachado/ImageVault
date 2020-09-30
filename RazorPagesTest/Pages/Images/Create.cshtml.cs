using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesTest.Data;
using RazorPagesTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace RazorPagesTest.Pages.Images
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesTest.Data.RazorPagesTestContext _context;
        private IWebHostEnvironment _environment;

        public CreateModel(RazorPagesTest.Data.RazorPagesTestContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Image Image { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public string Message { get; set; }
        public string ImagePath { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Request.Form.Files.Count > 0)
            {

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                //save file to database
                Image.Title = Upload.FileName;
                _context.Image.Add(Image);
                await _context.SaveChangesAsync();

                var file = Path.Combine(_environment.WebRootPath, "Uploads", Upload.FileName);

                //save file to specified file system
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                    ImagePath = Url.Content("~/Uploads/" + Upload.FileName);
                    Message = "complete";
                    return Page();
                }
            }
            else
            {
                Message = "incomplete";
                return Page();
            }
        }
    }
}
