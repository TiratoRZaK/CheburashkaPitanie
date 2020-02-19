using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дет.Сад.Питание.Models
{
    [Serializable]
    public class ActionDescription
    {
        public string name { get; set; }
        public List<string> description { get; set; }

        public ActionDescription(string name, params string[] desc)
        {
            this.name = name;
            description = new List<string>();
            foreach (string item in desc)
            {
                description.Add(item);
            }
        }
    }
}
