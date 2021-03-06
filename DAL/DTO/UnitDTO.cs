﻿using System;
using System.Collections.Generic;

namespace DAL.DTO
{
    [Serializable]
    public class UnitDTO
    {
        public UnitDTO()
        {
            this.Products = new HashSet<ProductDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<ProductDTO> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}