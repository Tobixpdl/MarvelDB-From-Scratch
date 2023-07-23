using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CharacterType Type { get; set; }
        public string MovieFA { get; set; } = null;
        public string SerieFA { get; set; } = null;
        public Alingment Alingment { get; set; }
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
