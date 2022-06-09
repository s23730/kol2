using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.DTO_s;

namespace WebApplication1.Models
{
    public class Musician_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public virtual Track Track { get; set; }
        public virtual Musician Musician { get; set; }
    }
}
