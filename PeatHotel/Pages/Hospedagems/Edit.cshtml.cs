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

namespace PeatHotel.Pages.Hospedagems
{
    public class EditModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public EditModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hospedagem Hospedagem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hospedagem = await _context.Hospedagem
                .Include(h => h.cliente)
                .Include(h => h.hospedagemTipo)
                .Include(h => h.peat)
                .Include(h => h.servico).FirstOrDefaultAsync(m => m.hospedagemId == id);

            if (Hospedagem == null)
            {
                return NotFound();
            }
           ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId");
           ViewData["hospedagemTipoId"] = new SelectList(_context.HospedagemTipo, "hospedagemTipoId", "hospedagemTipoId");
           ViewData["peatId"] = new SelectList(_context.Peat, "peatId", "peatId");
           ViewData["servicoId"] = new SelectList(_context.Servico, "servicoId", "servicoId");
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

            _context.Attach(Hospedagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospedagemExists(Hospedagem.hospedagemId))
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

        private bool HospedagemExists(int id)
        {
            return _context.Hospedagem.Any(e => e.hospedagemId == id);
        }
    }
}
