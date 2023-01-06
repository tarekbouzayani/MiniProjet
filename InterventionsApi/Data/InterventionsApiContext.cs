using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InterventionsApi.Models;

namespace InterventionsApi.Data
{
    public class InterventionsApiContext : DbContext
    {
        public InterventionsApiContext (DbContextOptions<InterventionsApiContext> options)
            : base(options)
        {
        }

        public DbSet<InterventionsApi.Models.Intervention> Intervention { get; set; } = default!;
        public DbSet<InterventionsApi.Models.Reclamation> Reclamation { get; set; } = default!;
        public DbSet<InterventionsApi.Models.Article> Article { get; set; } = default!;
        public DbSet<InterventionsApi.Models.Client> Client { get; set; } = default!;
        public DbSet<InterventionsApi.Models.Piece> Piece { get; set; } = default!;
        public DbSet<InterventionsApi.Models.Facture> Facture { get; set; } = default!;
        public DbSet<InterventionsApi.Models.PieceFacturee> PieceFacturee { get; set; } = default!;

    }
}
