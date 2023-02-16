using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Restanta_Medii_Cadis_Voicila.Models;

namespace Proiect_Restanta_Medii_Cadis_Voicila.Data
{
    public class Proiect_Restanta_Medii_Cadis_VoicilaContext : DbContext
    {
        public Proiect_Restanta_Medii_Cadis_VoicilaContext (DbContextOptions<Proiect_Restanta_Medii_Cadis_VoicilaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Restanta_Medii_Cadis_Voicila.Models.Masina> Masina { get; set; } = default!;

        public DbSet<Proiect_Restanta_Medii_Cadis_Voicila.Models.Reprezentanta> Reprezentanta { get; set; }

        public DbSet<Proiect_Restanta_Medii_Cadis_Voicila.Models.AgentInchirieri> AgentInchirieri { get; set; }

        public DbSet<Proiect_Restanta_Medii_Cadis_Voicila.Models.Categorie> Categorie { get; set; }

        public DbSet<Proiect_Restanta_Medii_Cadis_Voicila.Models.Membru> Membru { get; set; }

        public DbSet<Proiect_Restanta_Medii_Cadis_Voicila.Models.Inchiriere> Inchiriere { get; set; }
    }
}
