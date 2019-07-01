using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestApp.Web.Config
{
    public class EnemyConfig
    {
        public string Name { get; set; }
        public string[] Keys { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public string Description { get; set; }
        public string[] Loot { get; set; }
    }
}
