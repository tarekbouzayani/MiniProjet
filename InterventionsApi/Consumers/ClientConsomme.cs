using InterventionsApi.Data;
using InterventionsApi.Models;
using MassTransit;
using Shared;
using System.Composition;

namespace InterventionsApi.Consumers
{
    public class ClientConsomme : IConsumer<Shared.Client>
    {
        private readonly InterventionsApiContext _interventionsApiContext;
        public ClientConsomme(InterventionsApiContext interventionsApiContext)
        {
            _interventionsApiContext= interventionsApiContext;
        }
        public async Task Consume(ConsumeContext<Shared.Client> context)
        {
            try
            {
                var NewArticle = new Models.Client
                {
                    ClientId = context.Message.ClientId,
                    Name = context.Message.Name,
                    Email = context.Message.Email,
                };
                _interventionsApiContext.Add(NewArticle);
                await _interventionsApiContext.SaveChangesAsync();
            }

            catch (Exception ex)
            {

            }

        }


    }
}
