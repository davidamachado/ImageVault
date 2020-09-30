using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTest.Data;
using RazorPagesTest.Models;

namespace RazorPagesTest.Pages.Images
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTest.Data.RazorPagesTestContext _context;

        public DetailsModel(RazorPagesTest.Data.RazorPagesTestContext context)
        {
            _context = context;
        }

        public Image Image { get; set; }

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
    }
}
