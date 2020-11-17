using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.Servicos
{
    public class DeleteModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public DeleteModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Servico Servico { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Servico = await _context.Servico.FirstOrDefaultAsync(m => m.servicoId == id);

            if (Servico == null)
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

            Servico = await _context.Servico.FindAsync(id);

            if (Servico != null)
            {
                _context.Servico.Remove(Servico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
