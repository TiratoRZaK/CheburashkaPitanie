using System;

namespace DAL.DTO
{
    [Serializable]
    public class ProductDishDTO
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int ProductId { get; set; }
        public float Norm { get; set; }   // норма продукта определённого блюда. Используется в меню.

        public virtual DishDTO Dish { get; set; }
        public virtual ProductDTO Product { get; set; }
    }
}