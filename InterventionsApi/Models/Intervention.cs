
namespace InterventionsApi.Models
{
    public class Intervention
    {
        public int InterventionId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Gratuit { get; set; }

        public int? FactureId { get; set; }
        public Facture? Facture { get; set; }
        public int? ReclamationId { get; set; }
        public Reclamation? Reclamation { get; set; }

        public int? ArticleId { get; set; }
        public Article? Article { get; set; }
        
    }
}
