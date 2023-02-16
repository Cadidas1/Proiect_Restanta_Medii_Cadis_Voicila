using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Masini
{
    public class EditModel : CategoriiMasinaPageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public EditModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masina Masina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Masina == null)
            {
                return NotFound();
            }

            Masina = await _context.Masina
                .Include(b => b.Reprezentanta)
                .Include(b => b.AgentInchirieri)
                .Include(b => b.CategoriiMasina).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);


            
            if (Masina == null)
            {
                return NotFound();
            }

            PopulateCategorieAtribuitaMasinii(_context, Masina);

            var agentinchirieriList = _context.AgentInchirieri.Select(x => new
            {
                x.ID,
                FullName = x.Prenume + " " + x.Nume
            });
            ViewData["ReprezentantaID"] = new SelectList(_context.Set<Reprezentanta>(), "ID",
"NumeReprezentanta");
            ViewData["AgentInchirieriID"] = new SelectList(agentinchirieriList, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masinaToUpdate = await _context.Masina
                .Include(i => i.Reprezentanta)
                .Include(i => i.AgentInchirieri)
                .Include(i => i.CategoriiMasina)
                .ThenInclude(i => i.Categorie)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (masinaToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Masina>(
            masinaToUpdate,
            "Masina",
            i => i.Model, i => i.AgentInchirieriID,
            i => i.Pret, i => i.AnulFabricarii, i => i.ReprezentantaID))
            {
                UpdateCategoriiMasina(_context, selectedCategorii, masinaToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            //Apelam UpdateCategoriiMasina pentru a aplica informatiile din checkboxuri la entitatea Masini care
            //este editata
            UpdateCategoriiMasina(_context, selectedCategorii, masinaToUpdate);
            PopulateCategorieAtribuitaMasinii(_context, masinaToUpdate);
            return Page();
        }


    }

}


