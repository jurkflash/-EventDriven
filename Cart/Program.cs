using Cart.EventBusConsumer;
using Cart.Services;
using Cart.Services.Interfaces;
using MassTransit;

namespace Cart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUpdateService, UpdateService>();

            builder.Services.AddMassTransit(config =>
            {
                config.AddConsumer<SendCartConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://host.docker.internal:5672");

                    cfg.ReceiveEndpoint("SendCartQueue", c =>
                    {
                        c.ConfigureConsumer<SendCartConsumer>(ctx);
                    });

                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}