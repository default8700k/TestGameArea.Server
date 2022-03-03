using Microsoft.AspNetCore.SignalR;

namespace WebApplication
{
    public class RequestHandler : Hub
    {
        public Task SendMessage(string message)
        {
            if (message == "СЛОВО")
            {
                return this.Clients.All.SendAsync("MessageHandler", "ОСУЖДАЮ");
            }

            return this.Clients.All.SendAsync("MessageHandler", message);
        }
    }
}
