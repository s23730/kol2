using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.DTO_s.Response
{
    public class AlbumRes
    {
        public Album Album { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
