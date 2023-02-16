using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Pages.Membrii
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
            return Page();
        }

        [BindProperty]
        public Membru Membru { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Membru.Add(Membru);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
