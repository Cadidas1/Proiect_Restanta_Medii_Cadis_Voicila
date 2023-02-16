namespace Proiect_Restanta_Medii_Cadis_Voicila.Models
{
    public class DateMasina
    {
        public IEnumerable<Masina> Masini { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieMasina> CategoriiMasina { get; set; }
    }
}
