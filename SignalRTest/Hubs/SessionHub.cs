using Microsoft.AspNetCore.SignalR;
using SignalRTest.Interfaces;
using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public class SessionHub : Hub<ISessionHub>, ISessionHub
    {
        public async Task Notify(string username)
        {
            await Clients.All.Notify(username);
        }
    }
}
