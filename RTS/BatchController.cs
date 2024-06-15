using WebSocketSharp.Server;
using WebSocketSharp;
using Newtonsoft.Json;
using Application.DTO.Response;

namespace RTS
{
    public class BatchController : WebSocketBehavior
    {
        private static BatchRequest batchData;
        public static BatchRequest BatchData { get{ return batchData;  } set { batchData = value;} }
       
        protected override void OnOpen()
        {
            Send("Connected");
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Nuevo Lote de tarjetas:\n {e.Data}");
            batchData = JsonConvert.DeserializeObject<BatchRequest>(e.Data);
            Program.conveyerBelt.play();
        }

        public static UserDataDTO? getUserData(long cardNumber)
        {
            int i = -1;
            while (++i < batchData.UsersData.Count && batchData.UsersData[i].CardNumber != cardNumber) ;
            if(i < batchData.UsersData.Count)
                return batchData.UsersData[i];
            return null;
        }
    }
}
