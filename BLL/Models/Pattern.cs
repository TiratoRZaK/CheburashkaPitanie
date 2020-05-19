using DAL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Models
{
    [Serializable]
    public class Pattern
    {
        public string Name { get; set; }
        public List<DishDTO> DishesZ { get; set; }
        public List<DishDTO> DishesO { get; set; }
        public List<DishDTO> DishesP { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
