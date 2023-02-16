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
    public class EditModel : PageModel
    {
        private readonly Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext _context;

        public EditModel(Proiect_Restanta_Medii_Cadis_Voicila.Data.Proiect_Restanta_Medii_Cadis_VoicilaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inchiriere Inchiriere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inchiriere == null)
            {
                return NotFound();
            }

            var inchiriere =  await _context.Inchiriere.FirstOrDefaultAsync(m => m.ID == id);
            if (inchiriere == null)
            {
                return NotFound();
            }
            Inchiriere = inchiriere;
           ViewData["MasinaID"] = new SelectList(_context.Masina, "ID", "ID");
           ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inchiriere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InchiriereExists(Inchiriere.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InchiriereExists(int id)
        {
          return _context.Inchiriere.Any(e => e.ID == id);
        }
    }
}
