using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicacionwebyDocker.Data;

namespace AplicacionwebyDocker.Pages.crudPuesto
{
    public class CreateModel : PageModel
    {
        private readonly AplicacionwebyDocker.Data.ApplicationDbContext _context;

        public CreateModel(AplicacionwebyDocker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Puesto Puesto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Puestos == null || Puesto == null)
            {
                return Page();
            }

            _context.Puestos.Add(Puesto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
