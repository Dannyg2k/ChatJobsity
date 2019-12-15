using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatJobsity
{
    public class ChatHub : Hub
    {
        public static List<Client> ConnectedClients { get; set; } = new List<Client>();
       
        public void Connect(string _username)
        {
            Client c = new Client()
            {
                UserName = _username,
                Id = Context.ConnectionId

            };
            ConnectedClients.Add(c);
            Clients.All.updateUsers(ConnectedClients.Count(), ConnectedClients.Select(x => x.UserName));


        }
        public void Send(string _message)
        {
            if (!_message.Contains("/stock="))
            {
                var sender = ConnectedClients.First(x => x.Id.Equals(Context.ConnectionId));
                Clients.All.SendData(System.DateTime.UtcNow.AddHours(-5).ToString("yyyy-MM-dd HH:mm:ss") + " - " + sender.UserName, _message);
            }else
            {
                string _stockCode = _message.Split(new string[] { "/stock=" }, StringSplitOptions.None)[1];
                string _respuesta = new ChatJobsity.App_Code.StockProvider().GetStock(_stockCode);

                if (_respuesta.Split(',')[1] == "N/D")
                {
                    Clients.All.SendData(System.DateTime.UtcNow.AddHours(-5).ToString("yyyy-MM-dd HH:mm:ss") + " - Bot Stock", "the code of stock is not correct");
                }
                else
                    {
                    string[] _dataStock = _respuesta.Split(',');
                    Clients.All.SendData(System.DateTime.UtcNow.AddHours(-5).ToString("yyyy-MM-dd HH:mm:ss") + " - Bot Stock", String.Format("{0} quote is ${1} per share", _dataStock[0], _dataStock[3]));

                }
            }
        }

        public override  Task OnDisconnected(bool stopCalled)
        {
            var disconnectedUser = ConnectedClients.FirstOrDefault(x=> x.Id.Equals(Context.ConnectionId));
            ConnectedClients.Remove(disconnectedUser);
            Clients.All.updateUsers(ConnectedClients.Count(), ConnectedClients.Select(x => x.UserName));
            return base.OnDisconnected(stopCalled);
        }
    }

    public class Client
    {

      public  string UserName { get; set; }
      public  string Id { get; set; }
    }
}