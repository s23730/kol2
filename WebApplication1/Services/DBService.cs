using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTO_s;

namespace WebApplication1.Services
{
    public class DBService : IDBService
    {
        private readonly DBContext _context;
        public DBService(DBContext context)
        {
            _context = context;
        }
        public async Task<Album> GetAlbum(int id)
        {
            return _context.Albums.Single(a => a.IdAlbum == id);
        }
        public async Task<bool> DeleteMusician(int id)
        {
            try
            {
                Musician musician = _context.Musicians.Where(m => m.IdMusician == id).Single();
                IEnumerable<Musician_Track> musician_Tracks = musician.Musician_Tracks;
                bool flag = musician_Tracks.Select(m => m.Track).Where(track => !track.IdMusicAlbum.HasValue).Count() != 0;
                if (musician_Tracks.Count() != 0)
                {
                    if (!flag)
                    {
                        foreach (Musician_Track track in musician_Tracks)
                        {
                            _context.Musician_Tracks.Remove(track);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    _context.Musicians.Remove(musician);
                }
            }catch(Exception ex)
            {
            }
            return await SaveChanges();
        }
        public async Task<bool> SaveChanges()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
