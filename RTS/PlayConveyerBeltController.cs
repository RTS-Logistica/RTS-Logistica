using WebSocketSharp.Server;
using WebSocketSharp;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text;

namespace RTS
{
    public class PlayConveyerBeltController : WebSocketBehavior
    {   
        protected override void OnOpen()
        {
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }

        protected override void OnMessage(MessageEventArgs e)
        {
           Console.WriteLine($"CardController: {e.Data}");
        }
    }
}
