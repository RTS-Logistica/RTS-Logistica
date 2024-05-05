using WebSocketSharp.Server;

namespace RTS
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverAddress = "ws://localhost:8080";
            WebSocketServer server = new WebSocketServer(serverAddress);
            server.AddWebSocketService<BatchController>("/batch");
            server.AddWebSocketService<CardController>("/card");
            server.Start();
            Console.WriteLine($"Servidor WebSocket iniciado en {serverAddress}");
            Console.WriteLine("Presione cualquier tecla para detener el servidor.");
            Console.ReadKey(true);
            server.Stop();
        }       
    }

}