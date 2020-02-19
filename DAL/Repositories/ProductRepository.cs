using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class ProductRepository : IRepository<ProductDTO>
    {
        private PitanieContext db;

        public ProductRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(ProductDTO item)
        {
            db.Products.Add(item);
        }

        public void Delete(int id)
        {
            ProductDTO product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
            }
        }

        public IEnumerable<ProductDTO> Find(Func<ProductDTO, bool> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public ProductDTO Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return from a in db.Products select a;
        }

        public void Update(ProductDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}