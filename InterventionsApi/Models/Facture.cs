namespace InterventionsApi.Models
{
    public class Facture
    {
        public int FactureId { get; set; }
        public int? IntervetionId { get; set; }
        public Intervention? Intervention { get; set; }
        public double MainOeuvre { get; set; }
        

    }
}
