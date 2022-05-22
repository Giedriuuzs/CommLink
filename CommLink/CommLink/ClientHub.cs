using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace CommLink
{
    public class ClientHub : Hub
    {

        private static IHubContext<ClientHub> _clientHubContext;

        public ClientHub(IHubContext<ClientHub> clientHubContext)
        {
            _clientHubContext = clientHubContext;
        }

        // static Form1 form1 = new Form1(_clientHubContext);
        // form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
        List<string> stringList = new List<string>();
        Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault(); //.FirstOrDefault();
        /*
        private readonly IHubContext<ServerHub> _serverHubContext;

        public ClientHub(IHubContext<ServerHub> serverHubContext)
        {
            _serverHubContext = serverHubContext;
        }
        */
        public async Task SendMessage(string user, string message)
        {
            Console.WriteLine("Server received: User: " + user + " Message: " + message);

            await Clients.All.SendAsync("ReceiveMessage", user, message);

            Console.WriteLine("Server send: User: " + user + " Message: " + message);
        }

        public async Task NeedAllActiveComms()
        {
            //form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            //await _serverHubContext.Clients.All.SendAsync("GiveAllActiveComms");
            await Clients.All.SendAsync("ReceiveAllActiveComms", JsonConvert.SerializeObject(form1.Analyzers));
        }
        public async Task NeedCommLastData(int analyzerID)
        {
            // await _serverHubContext.Clients.All.SendAsync("GiveCommLastData", analyzerID);
            //form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            stringList = form1.GiveCommLastData(analyzerID);
            await Clients.All.SendAsync("ReceiveCommLastData", JsonConvert.SerializeObject(stringList));
        }

        public async Task turnOnOffCommunication(int analyzerID, bool onOff)
        {

            form1.turnOnOffCommunication(analyzerID, onOff);
            //await _serverHubContext.Clients.All.SendAsync("turnOnOffCommunication", analyzerID, onOff);
        }
    }
}
