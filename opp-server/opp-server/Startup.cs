using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Extensions.Hosting;
using opp_server.Hubs;
using opp_lib;
using opp_server.Classes.Observer;
using opp_server.Classes.Builder;
using opp_server.Classes;
using opp_server.Classes.Template;
using opp_server.Classes.Mediator;
using opp_server.Classes.Memento;

namespace opp_server
{
    public class Startup
    {
        public Director Director { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Director = new Director();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Ball createdBall = new Ball(40, 200, 200, "White");
            Builder builder = new BallBuilder(createdBall);
            createdBall = Director.ConstructDottyEdged(builder);

            BallMovement[] ballMovements = new BallMovement[]
                { new NormalBallMovement(createdBall), new FrictionlessBallMovement(createdBall), new NormalBallMovement(createdBall) };

            Originator originator = new Originator();

            services.AddSingleton(opt => GameState.GetInstance());
            services.AddSingleton(opt => new Server());
            services.AddSingleton(opt => new Level());
            services.AddSingleton(opt => createdBall);
            services.AddSingleton(opt => ballMovements);
            services.AddSingleton(opt => new ChatRoom());
            services.AddSingleton(opt => originator);
            services.AddSingleton(opt => new Caretaker());
            services.AddSignalR(o => {
                o.EnableDetailedErrors = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<GameHub>("/gamehub");
            });
        }
    }
}
