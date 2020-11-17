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
    public class DetailsModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public DetailsModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

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
    }
}
