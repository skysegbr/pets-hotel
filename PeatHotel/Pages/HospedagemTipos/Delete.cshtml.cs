using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.HospedagemTipos
{
    public class DeleteModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public DeleteModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HospedagemTipo HospedagemTipo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HospedagemTipo = await _context.HospedagemTipo.FirstOrDefaultAsync(m => m.hospedagemTipoId == id);

            if (HospedagemTipo == null)
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

            HospedagemTipo = await _context.HospedagemTipo.FindAsync(id);

            if (HospedagemTipo != null)
            {
                _context.HospedagemTipo.Remove(HospedagemTipo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
