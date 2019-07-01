using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Web.Config
{
    public class MainConfig
    {
        public string[][] Help { get; set; }
        public IDictionary<string, string[]> Inventory { get; set; }
        public RoomConfig[] Rooms { get; set; }
        public EnemyConfig[] Enemies { get; set; }
        public IDictionary<string, string> Messages { get; set; }
    }
}
