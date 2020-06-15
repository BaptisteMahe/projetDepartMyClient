using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCLient.DAL.Models
{
    /** Correspond une entrée dans la tbale Client de la BD */
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int NbConnections { get; set; }
    }
}
