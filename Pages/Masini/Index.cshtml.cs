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

        public IList<Masina> Masina { get; set; } = default!;
        public DateMasina MasinaD { get; set; }
        public int MasinaID { get; set; }
        public int CategorieID { get; set; }

        public string ModelSort { get; set; }
        public string AgentInchirieriSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID, string sortOrder, string
searchString)
        {
            MasinaD = new DateMasina();

            ModelSort = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            AgentInchirieriSort = String.IsNullOrEmpty(sortOrder) ? "AgentInchirieri_desc" : "";

            CurrentFilter = searchString;

            MasinaD.Masini = await _context.Masina
            .Include(b => b.Reprezentanta)
            .Include(b => b.AgentInchirieri)
            .Include(b => b.CategoriiMasina)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Model)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                MasinaD.Masini = MasinaD.Masini.Where(s => s.AgentInchirieri.Nume.Contains(searchString)

               || s.AgentInchirieri.Prenume.Contains(searchString)
               || s.Model.Contains(searchString));
            }


            if (id != null)
            {
                MasinaID = id.Value;
                Masina masina = MasinaD.Masini
                .Where(i => i.ID == id.Value).Single();
                MasinaD.Categorii = masina.CategoriiMasina.Select(s => s.Categorie);

                switch (sortOrder)
                {
                    case "model_desc":
                        MasinaD.Masini = MasinaD.Masini.OrderByDescending(s =>
                       s.Model);
                        break;
                    case "AgentInchirieri_desc":
                        MasinaD.Masini = MasinaD.Masini.OrderByDescending(s =>
                       s.AgentInchirieri.NumeComplet);
                        break;
                }
            }
        }

    }
}