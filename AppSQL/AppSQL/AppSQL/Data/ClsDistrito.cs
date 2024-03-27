using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AppSQL.Data
{
    public class ClsDistrito
    {
        public static List<Distrito> GetDistritos()
        {
            List<Distrito> ListaDistritos = new List<Distrito>();
            string sql = "Select id_dis, nom_dis from distritos";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            Distrito reg = new Distrito()
                            {
                                id = rd.GetInt32(0),    //id_dis
                                nom = rd.GetString(1),  //nom_dis                                
                            };

                            ListaDistritos.Add(reg);
                        }
                    }
                }
                con.Close();
                return ListaDistritos;
            }
        }
    }
}
