using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Model.Entities
{
    public class Music
    {
        public int Id { get; set; }
        public string Judul { get; set; }
        public string Genre { get; set; }
        public string Penyanyi { get; set; }
        public string Publish { get; set; }
        public int TahunRilis { get; set; }
    }

}
