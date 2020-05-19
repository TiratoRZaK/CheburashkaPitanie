using System;

namespace BLL.Models
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


        public float GetSum()
        {
            return Price * Balance;
        }

        public float GetSumRound()
        {
            return (float)Math.Round(Price * Balance, 2);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
