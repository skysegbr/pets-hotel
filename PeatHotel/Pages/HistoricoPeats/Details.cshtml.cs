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
    public class DetailsModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public DetailsModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        public HistoricoPeat HistoricoPeat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HistoricoPeat = await _context.HistoricoPeat.FirstOrDefaultAsync(m => m.histPeatId == id);

            if (HistoricoPeat == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
