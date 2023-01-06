using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArticlesApi.Models;

namespace ArticlesApi.Data
{
    public class ArticlesApiContext : DbContext
    {
        public ArticlesApiContext (DbContextOptions<ArticlesApiContext> options)
            : base(options)
        {
        }

        public DbSet<ArticlesApi.Models.Article> Article { get; set; } = default!;

        public DbSet<ArticlesApi.Models.Piece> Piece { get; set; }
    }
}
