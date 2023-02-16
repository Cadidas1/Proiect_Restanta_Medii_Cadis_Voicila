using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Models
{
    public class Membru
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? NumarDeTelefon { get; set; }
        [Display(Name = "Nume Complet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Inchiriere>? Inchirieri { get; set; }

    }
}

