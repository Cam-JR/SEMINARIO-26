using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AppSQL.Data
{
    public class ClsProductor
    {
        public static List<Productor> GetProductores()
        {
            List<Productor> listaProductores = new List<Productor>();
            string sql = "SELECT id_productor, nom_productor, ubica_cultivo, superficie FROM productor";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Productor reg = new Productor()
                            {
                                id_productor = rd.GetInt32(0),
                                nom_productor = rd.GetString(1),
                                ubica_cultivo = rd.GetString(2),
                                superficie = rd.GetInt32(3)
                            };

                            listaProductores.Add(reg);
                        }
                    }
                }
                con.Close();
                return listaProductores;
            }
        }

        public static void AgregarProductor(Productor productor)
        {
            string sql = "INSERT INTO productor (nom_productor, ubica_cultivo, superficie) VALUES (@nom_productor, @ubica_cultivo, @superficie)";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.AddWithValue("@nom_productor", productor.nom_productor);
                    comando.Parameters.AddWithValue("@ubica_cultivo", productor.ubica_cultivo);
                    comando.Parameters.AddWithValue("@superficie", productor.superficie);
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void ModificarProductor(Productor productor)
        {
            string sql = "UPDATE productor SET nom_productor = @nom_productor, ubica_cultivo = @ubica_cultivo, superficie = @superficie WHERE id_productor = @id";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.AddWithValue("@nom_productor", productor.nom_productor);
                    comando.Parameters.AddWithValue("@ubica_cultivo", productor.ubica_cultivo);
                    comando.Parameters.AddWithValue("@superficie", productor.superficie);
                    comando.Parameters.AddWithValue("@id", productor.id_productor);
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void EliminarProductor(Productor productor)
        {
            string sql = "DELETE FROM productor WHERE id_productor = @id";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.AddWithValue("@id", productor.id_productor);
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
