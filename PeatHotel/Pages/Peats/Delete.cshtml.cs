using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.Peats
{
    public class DeleteModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public DeleteModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Peat Peat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Peat = await _context.Peat.FirstOrDefaultAsync(m => m.peatId == id);

            if (Peat == null)
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

            Peat = await _context.Peat.FindAsync(id);

            if (Peat != null)
            {
                _context.Peat.Remove(Peat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
