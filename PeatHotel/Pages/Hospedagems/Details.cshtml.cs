using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.Hospedagems
{
    public class DetailsModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public DetailsModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
