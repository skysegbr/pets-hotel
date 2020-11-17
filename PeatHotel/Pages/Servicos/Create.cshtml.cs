using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.Servicos
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
            return Page();
        }

        [BindProperty]
        public Servico Servico { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Servico.Add(Servico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
