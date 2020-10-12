using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using DI;
using DIContracts;
using DrawPicContracts.Interface;
using DrawPicContracts.Interface.WebSocket;
using InfraContracts.Interfaces;
using InfraDal;
using InfraMessengerWS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;


namespace DrawPicApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connStr = Configuration.GetValue<string>("Oracle:strConn");
            services.AddCors();

            services.AddMvc();

  
            /*
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            */
            services.AddTransient<IInfraDal, InfraDalImpl>();
            services.AddTransient<IInfraMessengerWS, InfraMessengerWSImpl>();
            services.AddScoped<IConnectionString>(c => new ProductionDbContextConnectionString(connStr));
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dlls");
            var resolver = new Resolver(path, services);
            services.AddSingleton<IResolver>(sp => resolver);
            services.AddControllers();

            //swagger
            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //web socket
            app.UseWebSockets();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/ws/marker"))

                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        var markerWebSocketService = app.ApplicationServices.GetService<IMarkerWebSocket>();
                        await markerWebSocketService.AddConnection(webSocket);
                        var receive = await webSocket.ReceiveAsync(new Memory<byte>(), CancellationToken.None);
                        
                        if (receive.MessageType == WebSocketMessageType.Close)
                        {
                            await markerWebSocketService.RemoveConnection(webSocket);
                        } 
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }
            });

            app.UseHttpsRedirection();

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DrawPic API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            

            //app.UseCors(options => options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
