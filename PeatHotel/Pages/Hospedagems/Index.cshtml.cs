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
    public class IndexModel : PageModel
    {
        private readonly PeatHotel.Data.PeatContext _context;

        public IndexModel(PeatHotel.Data.PeatContext context)
        {
            _context = context;
        }

        public IList<Hospedagem> Hospedagem { get;set; }

        public async Task OnGetAsync()
        {
            Hospedagem = await _context.Hospedagem
                .Include(h => h.cliente)
                .Include(h => h.hospedagemTipo)
                .Include(h => h.peat)
                .Include(h => h.servico).ToListAsync();
        }
    }
}
