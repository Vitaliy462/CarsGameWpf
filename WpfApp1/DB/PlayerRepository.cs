using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DB
{
    class PlayerRepository : IRepository<Player>
    {
        private PlayerContext db;

        public PlayerRepository(PlayerContext _db)
        {
            db = _db;
        }

        public void Create(Player item)
        {
            db.Players.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Player item = get(id);
            if (item != null)
            {
                db.Players.Remove(item);
            }
        }

        public Player get(int id)
        {
            return db.Players.Find(id);
        }

        public IEnumerable<Player> getAll()
        {
            return db.Players;
        }

        public void Update(Player item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    
    }
}
