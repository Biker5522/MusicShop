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
       

        public void Update(Album obj)
        {
            var objFromDb = _db.Albums.FirstOrDefault(u=>u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Band = obj.Band;
                objFromDb.GenreId = obj.GenreId;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.Year = obj.Year;
                objFromDb.Price3 = obj.Price3;

                if (objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                } 


            }
        }
    }
}
