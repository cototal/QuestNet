using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Web.Services.ActionHandlers
{
    public interface IGameAction
    {
        string Output(string[] input);
    }
}
