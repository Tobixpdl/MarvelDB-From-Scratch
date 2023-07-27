using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Phase { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Imagen> Images { get; set; }
        public string ImageUrl
        {
            get
            {
                return Images?.FirstOrDefault()?.Url;
            }
        }
    }
}
