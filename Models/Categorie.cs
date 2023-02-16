namespace Proiect_Restanta_Medii_Cadis_Voicila.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string TipMasina { get; set; }
        public ICollection<CategorieMasina>? CategorieMasina { get; set; }
    }
}
