using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class TypeRepository : IRepository<TypeDTO>
    {
        private PitanieContext db;

        public TypeRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(TypeDTO item)
        {
            db.Types.Add(item);
        }

        public void Delete(int id)
        {
            TypeDTO Type = db.Types.Find(id);
            if (Type != null)
            {
                db.Types.Remove(Type);
            }
        }

        public IEnumerable<TypeDTO> Find(Func<TypeDTO, bool> predicate)
        {
            return db.Types.Where(predicate).ToList();
        }

        public TypeDTO Get(int id)
        {
            return db.Types.Find(id);
        }

        public IEnumerable<TypeDTO> GetAll()
        {
            return db.Types.ToList();
        }

        public void Update(TypeDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
