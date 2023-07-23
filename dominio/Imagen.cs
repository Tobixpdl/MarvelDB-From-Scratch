using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Character_Id { get; set; } = 0;
        public int Movie_Id { get; set; } = 0;
        public int Series_Id { get; set; } = 0;
    }
}
