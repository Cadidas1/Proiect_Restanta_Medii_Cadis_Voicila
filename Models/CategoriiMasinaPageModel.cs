using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Restanta_Medii_Cadis_Voicila.Data;
namespace Proiect_Restanta_Medii_Cadis_Voicila.Models
{
    public class CategoriiMasinaPageModel : PageModel
    {
        public List<CategorieAtribuitaMasinii> CategorieAtribuitaMasiniiList;
        public void PopulateCategorieAtribuitaMasinii(Proiect_Restanta_Medii_Cadis_VoicilaContext context,
        Masina masina)
        {
            var allCategorii = context.Categorie;
            var Categoriimasina = new HashSet<int>(
            masina.CategoriiMasina.Select(c => c.CategorieID)); //
            CategorieAtribuitaMasiniiList = new List<CategorieAtribuitaMasinii>();
            foreach (var cat in allCategorii)
            {
                CategorieAtribuitaMasiniiList.Add(new CategorieAtribuitaMasinii
                {
                    CategorieID = cat.ID,
                    Denumire = cat.TipMasina,
                    Atribuire = Categoriimasina.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategoriiMasina(Proiect_Restanta_Medii_Cadis_VoicilaContext context,
        string[] selectedCategorii, Masina masinaToUpdate)
        {
            if (selectedCategorii == null)
            {
                masinaToUpdate.CategoriiMasina = new List<CategorieMasina>();
                return;
            }
            var selectedCategoriiHS = new HashSet<string>(selectedCategorii);
            var Categoriimasina = new HashSet<int>
            (masinaToUpdate.CategoriiMasina.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if (!Categoriimasina.Contains(cat.ID))
                    {
                        masinaToUpdate.CategoriiMasina.Add(
                        new CategorieMasina
                        {
                            MasinaID = masinaToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (Categoriimasina.Contains(cat.ID))
                    {
                        CategorieMasina courseToRemove
                        = masinaToUpdate
                        .CategoriiMasina
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}



