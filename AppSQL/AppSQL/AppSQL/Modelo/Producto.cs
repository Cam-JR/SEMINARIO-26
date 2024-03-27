using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQL.Modelo
{
    public class Producto
    {
        public int id { get; set; }
        public string nom { get; set; }

        public int  id_tipo { get; set; } // int = entero

        public string nom_tipo { get; set; }

        public double pre_pro { get; set; } 

        public int id_productor { get; set; }

        public string nom_productor { get; set; }

        public string img_pro { get; set; }

        public string estado {  get; set; }

    }
}
