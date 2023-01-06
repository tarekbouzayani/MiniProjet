using InterventionsApi.Data;
using MassTransit;
using Shared;
using System.Composition;
using InterventionsApi.Models;

namespace InterventionsApi.Consumers
{
    public class ReclamationConsommee : IConsumer<Shared.Reclamation>
    {
        private readonly InterventionsApiContext _interventionsApiContext;
        public ReclamationConsommee(InterventionsApiContext interventionsApiContext)
        {
            _interventionsApiContext= interventionsApiContext;
        }
        public async Task Consume(ConsumeContext<Shared.Reclamation> context)
        {
            var NewArticle = new Models.Reclamation
            {
                ClientId = context.Message.ClientId,
                Description = context.Message.Description,
                Date = context.Message.Date,
                ReclamationId= context.Message.ReclamationId,
            };
            _interventionsApiContext.Add(NewArticle);
            await _interventionsApiContext.SaveChangesAsync();
        }


    }
}
