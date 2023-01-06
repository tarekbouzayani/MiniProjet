using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InterventionsApi.Data;
using MassTransit;
using InterventionsApi.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InterventionsApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InterventionsApiContext") ?? throw new InvalidOperationException("Connection string 'InterventionsApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ArticleConsomme>();
    x.AddConsumer<PieceConsommee>();
    x.AddConsumer<ClientConsomme>();
    x.AddConsumer<ReclamationConsommee>();


    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://localhost:4001"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("event-listener-newArticle", e =>
        {
            e.ConfigureConsumer<ArticleConsomme>(context);
        });
        
        cfg.ReceiveEndpoint("event-listener-newPiece", e =>
        {
            e.ConfigureConsumer<PieceConsommee>(context);
        });
        
        cfg.ReceiveEndpoint("event-listener-newClient", e =>
        {
            e.ConfigureConsumer<ClientConsomme>(context);
        });
        
        cfg.ReceiveEndpoint("event-listener-newReclamation", e =>
        {
            e.ConfigureConsumer<ReclamationConsommee>(context);
        });

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
