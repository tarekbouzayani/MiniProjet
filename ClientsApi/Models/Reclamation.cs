namespace ClientsApi.Models
{
    public class Reclamation
    {
        public int ReclamationId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? ClientId { get; set; }
        public Client? Client { get; set; } 
    }
}
