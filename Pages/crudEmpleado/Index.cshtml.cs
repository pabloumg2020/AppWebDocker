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
    public class IndexModel : PageModel
    {
        private readonly AplicacionwebyDocker.Data.ApplicationDbContext _context;

        public IndexModel(AplicacionwebyDocker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empleados != null)
            {
                Empleado = await _context.Empleados.ToListAsync();
            }
        }
    }
}
