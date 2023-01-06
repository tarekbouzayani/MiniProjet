using InterventionsApi.Data;
using MassTransit;
using Shared;
using System.Composition;
using InterventionsApi.Models;

namespace InterventionsApi.Consumers
{
    public class PieceConsommee : IConsumer<Shared.Piece>
    {
        private readonly InterventionsApiContext _interventionsApiContext;
        public PieceConsommee(InterventionsApiContext interventionsApiContext)
        {
            _interventionsApiContext= interventionsApiContext;
        }
        public async Task Consume(ConsumeContext<Shared.Piece> context)
        {
            var NewArticle = new Models.Piece
            {
                ArticleId = context.Message.ArticleId,
                Description = context.Message.Description,
                Prix = context.Message.Prix,
                PieceId= context.Message.PieceId,
            };
            _interventionsApiContext.Add(NewArticle);
            await _interventionsApiContext.SaveChangesAsync();
        }


    }
}
