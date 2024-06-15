using WebSocketSharp.Server;
using WebSocketSharp;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using Application.DTO.Response;
using Newtonsoft.Json;

namespace RTS
{
    public class BrochurePrinterStationController : WebSocketBehavior
    {
        protected override void OnOpen()
        {
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (!e.Data.Substring(0, 4).Equals("ping"))
                Console.WriteLine($"Impresora de folletos: {e.Data}");
        }
        public void SendMessage(CardResponse batchCard)
        {
            string batchCardTxt = JsonConvert.SerializeObject(batchCard);
            Send(batchCardTxt);
            Console.WriteLine(batchCardTxt);
        }
    }
}
