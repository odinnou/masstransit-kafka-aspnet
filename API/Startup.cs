using API.Models.Kafka;
using API.UseCases;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });

                x.AddRider(rider =>
                {
                    rider.AddConsumer<UpdateCommandConsumer>();

                    rider.UsingKafka((context, k) =>
                    {
                        // console app
                        //k.Host("localhost:9092");

                        // docker
                        k.Host("broker:9092");
                        //k.Host("host.docker.internal:9092");

                        k.TopicEndpoint<ITrackingUpdateCommand>("test", "test", e =>
                        {
                            e.ConfigureConsumer<UpdateCommandConsumer>(context);
                        });
                    });
                });
            });

            services.AddMassTransitHostedService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
