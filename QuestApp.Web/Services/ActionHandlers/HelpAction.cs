using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Web.Services.ActionHandlers
{
    public class HelpAction : IGameAction
    {
        public HelpAction(string[][] helpTopics)
        {
            HelpTopics = helpTopics;
        }

        public string[][] HelpTopics { get; }

        public string Output(string[] input)
        {
            var sb = new StringBuilder();
            foreach (var line in HelpTopics)
            {
                sb.Append(string.Join(" - ", line));
                sb.Append("<br />");
            }
            return sb.ToString();
        }
    }
}
