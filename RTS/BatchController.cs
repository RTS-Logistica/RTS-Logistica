using WebSocketSharp.Server;
using WebSocketSharp;

namespace RTS
{
    public class BatchController : WebSocketBehavior
    {
        protected override void OnOpen()
        {
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"BatchController: {e.Data}");
            //Send("BatchController response");
        }
    }
}
