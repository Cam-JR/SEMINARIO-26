using System;
using System.Collections.Generic;
using System.Text;

namespace AppSQL.Modelo
{
    public class Pedidos
    {
        public int id_ped {  get; set; } 

        public DateTime fec_ped { get; set; } // fecha de pedido

        public int id_ven {  get; set; } //id del vendedor
        public string nom_ven { get; set; }

        public decimal tot_ped { get; set; } //total de pedido

        public char est_ped { get; set; } //estado de pedido

        public decimal totales = 0;

    }
}
