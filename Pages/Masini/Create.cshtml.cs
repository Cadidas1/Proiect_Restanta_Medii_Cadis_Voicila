using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Masini
{
    public class CreateModel : CategoriiMasinaPageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public CreateModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var agentInchirierilist = _context.AgentInchirieri.Select(x => new
            {
                x.ID,
                FullName = x.Prenume + " " + x.Nume
            });
            ViewData["ReprezentantaID"] = new SelectList(_context.Set<Reprezentanta>(), "ID",
"NumeReprezentanta");
            ViewData["AgentInchirieriID"] = new SelectList(agentInchirierilist, "ID", "FullName");
            var masina = new Masina();
            masina.CategoriiMasina = new List<CategorieMasina>();
            PopulateCategorieAtribuitaMasinii(_context, masina);
            return Page();
        }

        [BindProperty]
        public Masina Masina { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newMasina = Masina;
            if (selectedCategorii != null)
            {
                newMasina.CategoriiMasina = new List<CategorieMasina>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new CategorieMasina
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newMasina.CategoriiMasina.Add(catToAdd);
                }
            }

            _context.Masina.Add(newMasina);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateCategorieAtribuitaMasinii(_context, newMasina);
            return Page();
        }

    }
}
