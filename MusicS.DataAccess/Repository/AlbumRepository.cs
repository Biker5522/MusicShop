using MusicS.DataAccess.Repository.IRepository;
using MusicS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicS.DataAccess.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private ApplicationDbContext _db;
        public AlbumRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Album obj)
        {
            _db.Albums.Update(obj);
        }
    }
}
