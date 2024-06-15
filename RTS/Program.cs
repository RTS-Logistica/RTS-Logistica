using System.Diagnostics;
using WebSocketSharp.Server;

namespace RTS
{
    class Program
    {
        public static BrochurePrinterStationController brochureService;
        public static EnvelopePrinterStationController envelopeService;
        public static ConveyerBeltController conveyerBelt;

        static void Main(string[] args)
        {
            string serverAddress = "ws://localhost:8080";
            WebSocketServer server = new WebSocketServer(serverAddress);
            server.AddWebSocketService<BatchController>("/batch");
            server.AddWebSocketService("/playConveyerBelt", () => {
                conveyerBelt = new ConveyerBeltController();
                return conveyerBelt;
            });
            server.AddWebSocketService<CardReaderController>("/cardReader");
            server.AddWebSocketService("/brochurePrinterStation", () => {
                brochureService = new BrochurePrinterStationController();
                return brochureService;
            });
            server.AddWebSocketService("/envelopePrinterStation", () => {
                envelopeService = new EnvelopePrinterStationController();
                return envelopeService;
            });
            server.Start();
            Console.WriteLine($"Servidor WebSocket iniciado en {serverAddress}");
            Console.WriteLine("Presione cualquier tecla para detener el servidor.");
            Console.ReadKey(true);
            server.Stop();
        }       
    }

}