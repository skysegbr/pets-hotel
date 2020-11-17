using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.HospedagemTipos
{
    public class EditModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public EditModel(PeatHotel.Data.PeatContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HospedagemTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospedagemTipoExists(HospedagemTipo.hospedagemTipoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HospedagemTipoExists(int id)
        {
            return _context.HospedagemTipo.Any(e => e.hospedagemTipoId == id);
        }
    }
}
