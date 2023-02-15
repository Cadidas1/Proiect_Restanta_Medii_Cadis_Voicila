namespace Proiect_Restanta_Medii_Cadis_Voicila.Models
{
    public class Reprezentanta
    {
        public int ID { get; set; }
        public string NumeReprezentanta { get; set; }
        public ICollection<Masina>? Masini { get; set; }
    }
}
