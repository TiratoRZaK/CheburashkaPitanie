using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class ContractRepository : IRepository<ContractDTO>
    {
        public PitanieContext db;

        public ContractRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(ContractDTO item)
        {
            db.Contracts.Add(item);
        }

        public void Delete(int id)
        {
            ContractDTO contract = db.Contracts.Find(id);
            if (contract != null)
            {
                db.Contracts.Remove(contract);
            }
        }

        public IEnumerable<ContractDTO> Find(Func<ContractDTO, bool> predicate)
        {
            return db.Contracts.Where(predicate).ToList();
        }

        public ContractDTO Get(int id)
        {
            return db.Contracts.Find(id);
        }

        public IEnumerable<ContractDTO> GetAll()
        {
            return db.Contracts.ToList();
        }

        public void Update(ContractDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
