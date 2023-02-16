using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Membrii
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public DeleteModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Membru Membru { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Membru == null)
            {
                return NotFound();
            }

            var membru = await _context.Membru.FirstOrDefaultAsync(m => m.ID == id);

            if (membru == null)
            {
                return NotFound();
            }
            else 
            {
                Membru = membru;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Membru == null)
            {
                return NotFound();
            }
            var membru = await _context.Membru.FindAsync(id);

            if (membru != null)
            {
                Membru = membru;
                _context.Membru.Remove(Membru);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
