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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTest.Data.RazorPagesTestContext _context;

        public IndexModel(RazorPagesTest.Data.RazorPagesTestContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; }

        public async Task OnGetAsync()
        {
            Image = await _context.Image.ToListAsync();
        }
    }
}
