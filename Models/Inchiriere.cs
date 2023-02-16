using System.ComponentModel.DataAnnotations;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Models
{
    public class Inchiriere
    {
        public int ID { get; set; }
        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }
        public int? MasinaID { get; set; }
        public Masina? Masina { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataReturnarii { get; set; }

    }
}

