using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Reprezentante
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public DeleteModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Reprezentanta Reprezentanta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reprezentanta == null)
            {
                return NotFound();
            }

            var reprezentanta = await _context.Reprezentanta.FirstOrDefaultAsync(m => m.ID == id);

            if (reprezentanta == null)
            {
                return NotFound();
            }
            else 
            {
                Reprezentanta = reprezentanta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reprezentanta == null)
            {
                return NotFound();
            }
            var reprezentanta = await _context.Reprezentanta.FindAsync(id);

            if (reprezentanta != null)
            {
                Reprezentanta = reprezentanta;
                _context.Reprezentanta.Remove(Reprezentanta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
