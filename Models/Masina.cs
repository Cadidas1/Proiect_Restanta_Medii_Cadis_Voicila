using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Models
{
    public class Masina
    {
        public int ID { get; set; }
        [Display(Name = "Model Masina")]
        public string Model { get; set; }
        public int? AgentInchirieriID { get; set; }
        public AgentInchirieri? AgentInchirieri { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        public DateTime AnulFabricarii { get; set; }

        public int? ReprezentantaID { get; set; }
        public Reprezentanta? Reprezentanta { get; set; }

        public ICollection<CategorieMasina>? CategoriiMasina { get; set; }
    } //

}

