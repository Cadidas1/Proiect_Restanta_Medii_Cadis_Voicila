using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;
using Proiect_Restanta_Medii_Cadis_Voicila.Models.VizualizareModele;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Reprezentante
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public IndexModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        public IList<Reprezentanta> Reprezentanta { get;set; } = default!;

        public ReprezentantaDateIndex ReprezentantaData { get; set; }
        public int ReprezentantaID { get; set; }
        public int MasinaID { get; set; }
        public async Task OnGetAsync(int? id, int? masinaID)
        {
            ReprezentantaData = new ReprezentantaDateIndex();
            ReprezentantaData.Reprezentante = await _context.Reprezentanta
            .Include(i => i.Masini)
            .ThenInclude(c => c.AgentInchirieri)
            .OrderBy(i => i.NumeReprezentanta)
            .ToListAsync();
            if (id != null)
            {
                ReprezentantaID = id.Value;
                Reprezentanta reprezentanta = ReprezentantaData.Reprezentante
                .Where(i => i.ID == id.Value).Single();
                ReprezentantaData.Masini = reprezentanta.Masini;
            }


        }
    }
}
