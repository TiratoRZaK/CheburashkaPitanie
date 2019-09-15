using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class DishRepository : IRepository<DishDTO>
    {
        public PitanieContext db;

        public DishRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(DishDTO item)
        {
            db.Dishes.Add(item);
            db.ProductDishes.AddRange(item.ProductsDishes);
        }

        public void Delete(int id)
        {
            DishDTO dish = db.Dishes.Find(id);
            if (dish != null)
            {
                db.Dishes.Remove(dish);
            }
        }

        public IEnumerable<DishDTO> Find(Func<DishDTO, bool> predicate)
        {
            return db.Dishes.Where(predicate).ToList();
        }

        public DishDTO Get(int id)
        {
            return db.Dishes.Find(id);
        }

        public IEnumerable<DishDTO> GetAll()
        {
            return db.Dishes.ToList();
        }

        public void Update(DishDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

    }
}