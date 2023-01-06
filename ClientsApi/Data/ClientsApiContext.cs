using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientsApi.Models;

namespace ClientsApi.Data
{
    public class ClientsApiContext : DbContext
    {
        public ClientsApiContext (DbContextOptions<ClientsApiContext> options)
            : base(options)
        {
        }

        public DbSet<ClientsApi.Models.Client> Client { get; set; } = default!;

        public DbSet<ClientsApi.Models.Reclamation> Reclamation { get; set; }
    }
}
