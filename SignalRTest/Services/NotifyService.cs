using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRTest.Hubs;
using SignalRTest.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRTest.Services
{
    public class NotifyService : BackgroundService
    {
        private IServiceProvider serviceProvider;
        private Timer Timer;
        public NotifyService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void DoWork(object state)
        {
            using (var service = serviceProvider.CreateScope())
            {
                var context = service.ServiceProvider.GetService<IHubContext<SessionHub, ISessionHub>>();
                context.Clients.All.Notify("magicmango");
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Timer = new Timer(DoWork, null, 1000, 1000);
            return Task.CompletedTask;
        }
    }
}
