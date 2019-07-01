using QuestApp.Web.Config;
using QuestApp.Web.Services.ActionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Web.Services
{
    public class ActionHandler
    {
        public MainConfig Config { get; }
        public IDictionary<string, IGameAction> Actions { get; }

        public ActionHandler(MainConfig config, IDictionary<string, IGameAction> actions)
        {
            Config = config;
            Actions = actions;
        }

        public string Execute(string message)
        {
            var pieces = message.Split(" ");
            if (pieces.Length == 0)
            {
                return "Please enter a command.";
            }
            var actionName = pieces[0].ToLower();
            if (!Actions.ContainsKey(actionName))
            {
                return $"Invalid command: {actionName}";
            }
            var action = Actions[actionName];
            return action.Output(pieces);
        }
    }
}
