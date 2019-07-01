using Microsoft.AspNetCore.SignalR;
using QuestApp.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Web.Hubs
{
    public class SampleHub : Hub
    {
        public SampleHub(ActionHandler actionHandler)
        {
            ActionHandler = actionHandler;
        }

        public ActionHandler ActionHandler { get; }

        public async Task SendMessage(string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", ActionHandler.Execute(message));
        }
    }
}
