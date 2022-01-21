using MusicS.DataAccess.Repository.IRepository;
using MusicS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicS.DataAccess.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private ApplicationDbContext _db;
        public GenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Genre obj)
        {
            _db.Genres.Update(obj);
        }
    }
}
