using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дет.Сад.Питание.Models
{
    [Serializable]
    public class ProductArrival
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Balance { get; set; }
        public int TypeId { get; set; }
        public int UnitId { get; set; }


        public float getSum()
        {
            return Price * Balance;
        }

        public float getSumRound()
        {
            return (float)Math.Round(Price * Balance, 2);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
