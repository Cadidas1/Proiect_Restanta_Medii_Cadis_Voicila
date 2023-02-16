using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Inchirieri
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public CreateModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()

        {
            var masinaList = _context.Masina
            .Include(b => b.AgentInchirieri)
            .Select(x => new
            {
                x.ID,
                MasinaNumeComplet = x.Model + " - " + x.AgentInchirieri.Prenume + " " +
           x.AgentInchirieri.Nume
            });

                ViewData["MasinaID"] = new SelectList(masinaList, "ID", "MasinaNumeComplet");
        ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Inchiriere Inchiriere { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inchiriere.Add(Inchiriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
