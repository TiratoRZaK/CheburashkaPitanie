using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дет.Сад.Питание.Models
{
    [Serializable]
    public class Log
    {
        public DateTime time { get; set; }
        public string message { get; set; }
        public List<ActionDescription> actions { get; set; }

        public override string ToString()
        {
            return time.ToString()+" : "+message+".";
        }

        public Log(string message, List<ActionDescription> actions)
        {
            time = DateTime.Now;
            this.message = message;
            this.actions = new List<ActionDescription>();
            foreach (ActionDescription action in actions)
            {
                this.actions.Add(action);
            }
        }
    }
}
