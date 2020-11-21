using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.HistoricoPeats
{
    public class IndexModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public IndexModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        public IList<HistoricoPeat> HistoricoPeat { get;set; }

        public async Task OnGetAsync()
        {
            HistoricoPeat = await _context.HistoricoPeat.ToListAsync();
        }
    }
}
