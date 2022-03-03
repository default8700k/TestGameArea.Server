using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/request")
                .Build();

            await connection.StartAsync();

            connection.On<string>("MessageHandler", MessageHandler);

            while (true)
            {
                string message = Console.ReadLine();
                await connection.InvokeAsync("SendMessage", message);
            }
        }

        private static void MessageHandler(string message)
        {
            Console.WriteLine($"Получено сообщение от сервера!!! {message}");
        }
    }
}
