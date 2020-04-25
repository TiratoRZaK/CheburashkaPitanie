﻿using DAL.DTO;
using System;
using System.Collections.Generic;

namespace Дет.Сад.Питание.Models
{
    [Serializable]
    public class Menu : LocalModel
    {
        public DateTime DateCreate { get; set; }
        public List<DishDTO> DishesZ { get; set; }
        public List<DishDTO> DishesO { get; set; }
        public List<DishDTO> DishesP { get; set; }
        public List<ProductInMenu> Products { get; set; }

        public Menu()
        {
            DishesZ = new List<DishDTO>();
            DishesO = new List<DishDTO>();
            DishesP = new List<DishDTO>();
            Products = new List<ProductInMenu>();
        }
    }
}
