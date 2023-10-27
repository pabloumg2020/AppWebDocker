using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicacionwebyDocker.Data;

namespace AplicacionwebyDocker.Pages.crudEmpleado
{
    public class DetailsModel : PageModel
    {
        private readonly AplicacionwebyDocker.Data.ApplicationDbContext _context;

        public DetailsModel(AplicacionwebyDocker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Empleado Empleado { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.idEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }
            else 
            {
                Empleado = empleado;
            }
            return Page();
        }
    }
}
