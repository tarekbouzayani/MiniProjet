using System.ComponentModel.DataAnnotations.Schema;

namespace InterventionsApi.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        

    }
}
