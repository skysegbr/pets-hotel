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
    public class DeleteModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public DeleteModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HistoricoPeat = await _context.HistoricoPeat.FindAsync(id);

            if (HistoricoPeat != null)
            {
                _context.HistoricoPeat.Remove(HistoricoPeat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
