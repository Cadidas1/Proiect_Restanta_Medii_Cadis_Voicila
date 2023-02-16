using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Inchirieri
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public DeleteModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Inchiriere Inchiriere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }

            var inchiriere = await _context.Inchiriere.FirstOrDefaultAsync(m => m.ID == id);

            if (inchiriere == null)
            {
                return NotFound();
            }
            else 
            {
                Inchiriere = inchiriere;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }
            var inchiriere = await _context.Inchiriere.FindAsync(id);

            if (inchiriere != null)
            {
                Inchiriere = inchiriere;
                _context.Inchiriere.Remove(Inchiriere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
