using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQL.Modelo
{
    public class Productor
    { 
        public int id_productor { get; set; }
        public string nom_productor { get; set; }
        public string ubica_cultivo { get; set; }
        public int superficie { get; set; }
    }
}
