using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PeatHotel.Data;
using PeatHotel.Models;

namespace PeatHotel.Pages.Peats
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
        public Peat Peat { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Peat.Add(Peat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
