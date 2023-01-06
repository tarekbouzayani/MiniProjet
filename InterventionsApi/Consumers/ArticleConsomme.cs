using InterventionsApi.Data;
using MassTransit;
using Shared;
using System.Composition;
using InterventionsApi.Models;

namespace InterventionsApi.Consumers
{
    public class ArticleConsomme : IConsumer<Shared.Article>
    {
        private readonly InterventionsApiContext _interventionsApiContext;
        public ArticleConsomme(InterventionsApiContext interventionsApiContext)
        {
            _interventionsApiContext= interventionsApiContext;
        }
        public async Task Consume(ConsumeContext<Shared.Article> context)
        {
            var NewArticle = new Models.Article
            {
                ArticleId = context.Message.ArticleId,
                Name = context.Message.Name,
                Garantie = context.Message.Garantie,
            };
            _interventionsApiContext.Add(NewArticle);
            await _interventionsApiContext.SaveChangesAsync();
        }


    }
}
