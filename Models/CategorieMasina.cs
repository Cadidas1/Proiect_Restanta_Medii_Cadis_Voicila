namespace Proiect_Restanta_Medii_Cadis_Voicila.Models
{
    public class CategorieMasina
    {
        public int ID { get; set; }
        public int MasinaID { get; set; }
        public Masina Masina { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
