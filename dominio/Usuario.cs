using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashPass { get; set; }
        public string FullName { get; set; }
        public string Salt { get; set; }
        public long DNI { get; set; }
        public string Email { get; set; }
    }
}
