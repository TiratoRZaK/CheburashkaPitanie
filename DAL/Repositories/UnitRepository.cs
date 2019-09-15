using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class UnitRepository : IRepository<UnitDTO>
    {
        private PitanieContext db;

        public UnitRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(UnitDTO item)
        {
            db.Units.Add(item);
        }

        public void Delete(int id)
        {
            UnitDTO unit = db.Units.Find(id);
            if (unit != null)
            {
                db.Units.Remove(unit);
            }
        }

        public IEnumerable<UnitDTO> Find(Func<UnitDTO, bool> predicate)
        {
            return db.Units.Where(predicate).ToList();
        }

        public UnitDTO Get(int id)
        {
            return db.Units.Find(id);
        }

        public IEnumerable<UnitDTO> GetAll()
        {
            return db.Units.ToList();
        }

        public void Update(UnitDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}