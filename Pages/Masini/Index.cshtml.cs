using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Masini
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public IndexModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        public IList<Masina> Masina { get;set; } = default!;

        public string AgentInchirieriSort { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID, string sortOrder, string
searchString)
        {
            if (_context.Masina != null)
            {
                Masina = await _context.Masina
                    .Include(b => b.Reprezentanta)

                    .ToListAsync();
            }
        }
    }
}
