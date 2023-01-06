namespace InterventionsApi.Models
{
    public class PieceFacturee
    {
        public int PieceFactureeId { get; set; }

        public int? PieceId { get; set; }
        public Piece? Piece { get; set; }

        public int Quantite { get; set; }
    }
}
