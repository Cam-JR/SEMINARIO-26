using AppSQL.Listados;
using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppSQL.Data
{
    public class ClsPedido
    {
        public static List<Pedidos> GetPedidos()
        {
            List<Pedidos> listaPedidosVenta = new List<Pedidos>();

            string sql = "SELECT id_ped, fec_ped, v.nom_ven, tot_ped, est_ped FROM pedidos p INNER JOIN vendedores v on p.id_ven = v.id_ven";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
 

                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Pedidos reg = new Pedidos()
                            {
                                id_ped = rd.GetInt32(0),
                                fec_ped = rd.GetDateTime(1),
                                nom_ven = rd.GetString(2),
                                tot_ped = rd.GetDecimal(3),
                                est_ped = Convert.ToString(rd["est_ped"])[0],
                            };
                            reg.totales += reg.tot_ped;
                            listaPedidosVenta.Add(reg);
                        }
                    }
                }
                con.Close();

                return listaPedidosVenta;
            }  
        }

        public static decimal GetTotal()
        {
            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                decimal total = 0;
                con.Open();
                SqlCommand cmd = new SqlCommand("sum_total", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    total = (decimal)Convert.ToDouble(dr["suma"]);
                }
                con.Close();
                return total;
            }
        }
        public static void AgregarPedido(Pedidos pedidos)
        {
            string sql = "INSERT INTO pedidos (fec_ped, id_ven, tot_ped, est_ped) VALUES (@fec_ped, @id_ven, @tot_ped, @est_ped)";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.AddWithValue("@fec_ped", pedidos.fec_ped);
                    comando.Parameters.AddWithValue("@id_ven", pedidos.id_ven);
                    comando.Parameters.AddWithValue("@tot_ped", pedidos.tot_ped);
                    comando.Parameters.AddWithValue("@est_ped", pedidos.est_ped);
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void ModificarPedidos(Pedidos pedidos)
        {
            string sql = "UPDATE pedidos SET fec_ped = @fec_ped, id_ven = @id_ven, tot_ped = @tot_ped, est_ped = @est_ped WHERE id_ped = @id_ped";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.AddWithValue("@fec_ped", pedidos.fec_ped);
                    comando.Parameters.AddWithValue("@id_ven", pedidos.id_ven);
                    comando.Parameters.AddWithValue("@tot_ped", pedidos.tot_ped);
                    comando.Parameters.AddWithValue("@est_ped", pedidos.est_ped);
                    comando.ExecuteNonQuery();
                }
                    con.Close();
            }
        }

        public static void EliminarPedidos(Pedidos pedidos)
        {
            string sql = "DELETE FROM pedidos WHERE id_ped = @id_ped";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.AddWithValue("@id_ped", pedidos.id_ped);
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }

    }
}
