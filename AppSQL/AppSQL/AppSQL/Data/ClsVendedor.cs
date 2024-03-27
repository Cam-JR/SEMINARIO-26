using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Xamarin.Essentials;

namespace AppSQL.Data
{
    public class ClsVendedor
    {
        public static List<Vendedor> GetVendedor()
        {
            List<Vendedor> ListaVendedores = new List<Vendedor>();
            string sql = "Select v.id_ven, v.dni_ven, v.nom_ven, v.ape_ven,d.id_dis, d.nom_dis, v.correo_ven from vendedores v inner join distritos d on v.id_dis = d.id_dis";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Vendedor reg = new Vendedor()
                            {
                                id = rd.GetInt32(0),    //id_ven
                                dni = rd.GetString(1),  //dni_ven
                                nom = rd.GetString(2),  //nom_ven
                                ape = rd.GetString(3),  //ape_ven
                                id_dis = rd.GetInt32(4),
                                nom_dis = rd.GetString(5),
                                correo = rd.GetString(6),
                            };

                            ListaVendedores.Add(reg);
                        }
                    }
                }
                con.Close();
                return ListaVendedores;
            }
        }

        public static void AgregarVendedor(Vendedor vendedor)
        {
            
            string sql = "sp_ingVendedor";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@dni_ven", SqlDbType.Char, 8).Value = vendedor.dni;
                    comando.Parameters.Add("@nom_ven", SqlDbType.VarChar, 30).Value = vendedor.nom;
                    comando.Parameters.Add("@ape_ven", SqlDbType.VarChar, 30).Value = vendedor.ape;
                    comando.Parameters.Add("@id_dis", SqlDbType.Int).Value = vendedor.id_dis;
                    comando.Parameters.Add("@correo_ven", SqlDbType.VarChar, 40).Value = vendedor.correo;                    
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }


        public static void ModificarVendedor(Vendedor vendedor)
        {

            string sql = "update Vendedores set dni_ven = @dni, nom_ven = @nom, ape_ven = @ape, id_dis = @iddis, correo_ven=@correo where id_ven = @id";

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cnx))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@dni", SqlDbType.Char, 8).Value = vendedor.dni;
                        comando.Parameters.Add("@nom", SqlDbType.VarChar, 25).Value = vendedor.nom;
                        comando.Parameters.Add("@ape", SqlDbType.VarChar, 25).Value = vendedor.ape;
                        comando.Parameters.Add("@iddis", SqlDbType.Int).Value = vendedor.id_dis;
                        comando.Parameters.Add("@correo", SqlDbType.VarChar, 40).Value = vendedor.correo;
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = vendedor.id;
                        comando.CommandType = CommandType.Text;                        
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                string res = ex.Message;
                
            }
        }
        public static void EliminarVendedor(Vendedor vendedor)
        {
            string sql = "delete from vendedores where id_ven = @id";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = vendedor.id;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }
    }
}
