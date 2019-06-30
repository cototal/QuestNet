using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Web.Hubs
{
    public class SampleHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", $"Processed message: {message}");
        }
    }
}
