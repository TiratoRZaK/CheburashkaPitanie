using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дет.Сад.Питание.Models
{
    [Serializable]
    public class ProductInMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, float> Norms { get; set; }
        public float Price { get; set; }
        public double SumNorms { get; set; }
        public double TotalOfKids { get; set; }

        public ProductInMenu(int Id, string Name, float Price, int dishId, float Norm, int Kids, int KidsB, bool B)
        {
            if (!B)
            {
                this.Id = Id;
                this.Name = Name;
                this.Price = Price;
                this.Norms = new Dictionary<int, float>();
                Norms.Add(dishId, Norm);
                this.SumNorms = SetSumm();
                this.TotalOfKids = Math.Round((Kids+KidsB) * SumNorms, 2);
            }
            else
            {
                this.Id = Id;
                this.Name = Name;
                this.Price = Price;
                this.Norms = new Dictionary<int, float>();
                this.SumNorms = Math.Round((((14 * KidsB) / Price)/KidsB),3);
                this.TotalOfKids = Math.Round(KidsB * SumNorms, 2);
            }
        }

        public void AddNorm(int dishId, float norm)
        {
            this.Norms.Add(dishId, norm);
            this.SumNorms = SetSumm();
        }

        public void SetNewTotalOfKids(int kids)
        {
            this.TotalOfKids = Math.Round(kids * SumNorms, 2);
        }

        public double SetSumm()
        {
            double norms = 0;
            foreach (double norm in Norms.Values)
            {
                norms = norms + norm;
            }
            return Math.Round( norms , 3 );
        }
    }
}
