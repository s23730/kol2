using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    interface IDBService
    {
        Task<Album> GetAlbum(int id);
        Task<bool> DeleteMusician(int id);
    }
}
