using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    class CustomerRepository : IRepository<CustomerDTO>
    {
        public PitanieContext db;

        public CustomerRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(CustomerDTO item)
        {
            db.Customers.Add(item);
        }

        public void Delete(int id)
        {
            CustomerDTO dish = db.Customers.Find(id);
            if (dish != null)
            {
                db.Customers.Remove(dish);
            }
        }

        public IEnumerable<CustomerDTO> Find(Func<CustomerDTO, bool> predicate)
        {
            return db.Customers.Where(predicate).ToList();
        }

        public CustomerDTO Get(int id)
        {
            return db.Customers.Find(id);
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            return db.Customers.ToList();
        }

        public void Update(CustomerDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
