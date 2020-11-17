using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.Hospedagems
{
    public class CreateModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public CreateModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["clienteId"] = new SelectList(_context.Cliente, "clienteId", "clienteId");
        ViewData["hospedagemTipoId"] = new SelectList(_context.HospedagemTipo, "hospedagemTipoId", "hospedagemTipoId");
        ViewData["peatId"] = new SelectList(_context.Peat, "peatId", "peatId");
        ViewData["servicoId"] = new SelectList(_context.Servico, "servicoId", "servicoId");
            return Page();
        }

        [BindProperty]
        public Hospedagem Hospedagem { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hospedagem.Add(Hospedagem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
