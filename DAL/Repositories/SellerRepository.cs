using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    class SellerRepository : IRepository<SellerDTO>
    {
        public PitanieContext db;

        public SellerRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(SellerDTO item)
        {
            db.Sellers.Add(item);
        }

        public void Delete(int id)
        {
            SellerDTO dish = db.Sellers.Find(id);
            if (dish != null)
            {
                db.Sellers.Remove(dish);
            }
        }

        public IEnumerable<SellerDTO> Find(Func<SellerDTO, bool> predicate)
        {
            return db.Sellers.Where(predicate).ToList();
        }

        public SellerDTO Get(int id)
        {
            return db.Sellers.Find(id);
        }

        public IEnumerable<SellerDTO> GetAll()
        {
            return db.Sellers.ToList();
        }

        public void Update(SellerDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
