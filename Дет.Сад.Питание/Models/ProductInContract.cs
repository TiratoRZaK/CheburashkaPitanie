using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дет.Сад.Питание.Models
{
    [Serializable]
    public class ProductInContract
    {
        public string Name { get; }
        public string Unit { get; }
        public float Price { get; }
    }
}
