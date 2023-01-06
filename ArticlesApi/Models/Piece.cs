namespace ArticlesApi.Models
{
    public class Piece
    {
        public int PieceId { get; set; }
        public string Description { get; set; } = String.Empty;
        public double Prix { get; set; }
        public int? ArticleId { get; set; }
        public Article? Article { get; set; }
    }
}
