using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class MenuRepository : IRepository<MenuDTO>
    {
        public PitanieContext db;

        public MenuRepository(PitanieContext context)
        {
            db = context;
        }

        public void Create(MenuDTO item)
        {
            db.Menus.Add(item);
        }

        public void Delete(int id)
        {
            MenuDTO menu = db.Menus.Find(id);
            if (menu != null)
            {
                db.Menus.Remove(menu);
            }
        }

        public IEnumerable<MenuDTO> Find(Func<MenuDTO, bool> predicate)
        {
            return db.Menus.Where(predicate).ToList();
        }

        public MenuDTO Get(int id)
        {
            return db.Menus.Find(id);
        }

        public IEnumerable<MenuDTO> GetAll()
        {
            return from a in db.Menus orderby a.Date select a;
        }

        public void Update(MenuDTO item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
