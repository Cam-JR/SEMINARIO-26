using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQL.Modelo
{
    public class Vendedor
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string nom { get; set; }
        public string ape { get; set; }
        public int id_dis { get; set; }
        public string nom_dis { get; set; }
        public string correo { get; set; }
    }
}
