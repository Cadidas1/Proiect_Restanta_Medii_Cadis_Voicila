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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public DetailsModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

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
    }
}
