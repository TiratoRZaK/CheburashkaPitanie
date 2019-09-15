using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class DeliveryNoteRepository : IRepository<DeliveryNoteDTO>
    {
        public PitanieContext db;

        public DeliveryNoteRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(DeliveryNoteDTO item)
        {
            db.DeliveryNotes.Add(item);
        }

        public void Delete(int id)
        {
            DeliveryNoteDTO deliveryNote = db.DeliveryNotes.Find(id);
            if (deliveryNote != null)
            {
                db.DeliveryNotes.Remove(deliveryNote);
            }
        }

        public IEnumerable<DeliveryNoteDTO> Find(Func<DeliveryNoteDTO, bool> predicate)
        {
            return db.DeliveryNotes.Where(predicate).ToList();
        }

        public DeliveryNoteDTO Get(int id)
        {
            return db.DeliveryNotes.Find(id);
        }

        public IEnumerable<DeliveryNoteDTO> GetAll()
        {
            return db.DeliveryNotes.ToList();
        }

        public void Update(DeliveryNoteDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
