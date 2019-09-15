using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class InvoiceRepository : IRepository<InvoiceDTO>
    {
        public PitanieContext db;

        public InvoiceRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(InvoiceDTO item)
        {
            db.Invoices.Add(item);
        }

        public void Delete(int id)
        {
            InvoiceDTO invoice = db.Invoices.Find(id);
            if (invoice != null)
            {
                db.Invoices.Remove(invoice);
            }
        }

        public IEnumerable<InvoiceDTO> Find(Func<InvoiceDTO, bool> predicate)
        {
            return db.Invoices.Where(predicate).ToList();
        }

        public InvoiceDTO Get(int id)
        {
            return db.Invoices.Find(id);
        }

        public IEnumerable<InvoiceDTO> GetAll()
        {
            return db.Invoices.ToList();
        }

        public void Update(InvoiceDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
