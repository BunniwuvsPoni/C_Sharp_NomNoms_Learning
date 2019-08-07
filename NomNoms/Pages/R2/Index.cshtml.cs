using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NomNoms.Core;
using NomNoms.Data;

namespace NomNoms.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly NomNoms.Data.NomNomsDbContext _context;

        public IndexModel(NomNoms.Data.NomNomsDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
