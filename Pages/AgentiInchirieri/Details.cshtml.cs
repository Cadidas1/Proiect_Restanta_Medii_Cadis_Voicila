using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.AgentiInchirieri
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public DetailsModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

      public AgentInchirieri AgentInchirieri { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AgentInchirieri == null)
            {
                return NotFound();
            }

            var agentinchirieri = await _context.AgentInchirieri.FirstOrDefaultAsync(m => m.ID == id);
            if (agentinchirieri == null)
            {
                return NotFound();
            }
            else 
            {
                AgentInchirieri = agentinchirieri;
            }
            return Page();
        }
    }
}
