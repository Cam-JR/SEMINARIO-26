using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace AppSQL.Data
{
    public  class ClsTipos
    {
        public static List<Tipos> GetTipos()
        {
            List<Tipos> Listatipos = new List<Tipos>();
            string sql = "Select id_tipo, nom_tipo, des_tipo,img_tipo, estado from tipos_cafe";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Tipos reg = new Tipos()
                            {
                                id = rd.GetInt32(0),    //id_tipo
                                nom = rd.GetString(1),  //nom_tipo
                                des = rd.GetString(2),  //des_tipo
                                img = (rd.GetString(3) is null) ? "": rd.GetString(3),
                                estado = (rd.GetString(4).Equals("A")) ? "Activo" : "Desactivado"  //estado
                            };

                            Listatipos.Add(reg);
                        }
                    }
                }
                con.Close();
                return Listatipos;
            }
        }

        public static void AgregarTipo(Tipos tipo)
        {
            string est = tipo.estado.ToString().Substring(0, 1);            
            string sql = "sp_ingTipo";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {                    
                    comando.Parameters.Add("@nom_tipo", SqlDbType.VarChar, 30).Value = tipo.nom;
                    comando.Parameters.Add("@des_tipo", SqlDbType.VarChar, 100).Value = tipo.des;
                    comando.Parameters.Add("@img_tipo", SqlDbType.VarChar, 500).Value = tipo.img;
                    comando.Parameters.Add("@Estado", SqlDbType.Char, 1).Value = est;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public static void ModificarTipo(Tipos tipo)
        {
            string est = tipo.estado.ToString().Substring(0, 1);
            string sql = "update tipos_cafe set nom_tipo = @nom, des_tipo = @des, img_tipo=@img, estado = @estado where id_tipo = @id";

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cnx))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@nom", SqlDbType.VarChar, 30).Value = tipo.nom;
                        comando.Parameters.Add("@des", SqlDbType.VarChar, 100).Value = tipo.des;
                        comando.Parameters.Add("@img", SqlDbType.VarChar, 100).Value = tipo.img;
                        comando.Parameters.Add("@estado", SqlDbType.Char, 1).Value = est;
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = tipo.id;
                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void EliminarTipo(Tipos tipo)
        {
            string sql = "delete from tipos_cafe where id_tipo = @id";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = tipo.id;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }
    }
}
