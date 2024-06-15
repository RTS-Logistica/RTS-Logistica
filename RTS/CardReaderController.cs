using WebSocketSharp.Server;
using WebSocketSharp;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using Application.DTO.Response;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RTS
{
    public class CardReaderController : WebSocketBehavior
    {
        protected override void OnOpen()
        {
        }

        protected override void OnClose(CloseEventArgs e)
        {
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (!e.Data.Substring(0,4).Equals("ping"))
            {
                Console.WriteLine($"CardController: {e.Data}");
                long cardNumber = JsonConvert.DeserializeObject<long>(e.Data);
                UserDataDTO userData = BatchController.getUserData(cardNumber);
                CardResponse cardData = new CardResponse()
                {
                    BatchId = BatchController.BatchData.BatchId,
                    BankName = BatchController.BatchData.BankName,
                    Slogan = BatchController.BatchData.Slogan,
                    Logo = BatchController.BatchData.Logo,
                    UsersData = userData
                };
                Program.brochureService.SendMessage(cardData);
                Program.envelopeService.SendMessage(cardData);
            }
        }
    }
}
