using System.ComponentModel.DataAnnotations.Schema;

namespace InterventionsApi.Models
{
    public class Article

    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public bool Garantie { get; set; }

    }
}
