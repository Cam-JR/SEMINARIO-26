using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace AppSQL.Data
{
     public class ClsProductos
     {
        public static List<Producto> GetProductos()
        {
            List<Producto> ListaProductos = new List<Producto>();

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                SqlCommand cmd = new SqlCommand("listado_productos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                 
                 
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Producto reg = new Producto()
                            {
                                id = Convert.ToInt32(dr["id_pro"]),
                                nom = dr["nom_pro"].ToString(),
                                nom_tipo = Convert.ToString(dr["nom_tipo"]),
                                pre_pro = Convert.ToDouble(dr["pre_pro"]),
                                nom_productor = Convert.ToString(dr["nom_productor"]),
                                //img_pro = dr.IsDBNull(5) ? "" : dr["img_pro"].ToString(),
                                estado = dr["estado"].ToString() == "A" ? "Activo" : "Desactivado"
                            };

                            ListaProductos.Add(reg);
                        }
                    }
                    con.Close();
                    return ListaProductos;
                
            }
        }

        public static void AgregarProducto(Producto producto)
        {
            string sql = "sp_ingProductos";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@nom_pro", SqlDbType.VarChar, 25).Value = producto.nom;
                    comando.Parameters.Add("@id_tipo", SqlDbType.Int).Value = producto.id_tipo;
                    comando.Parameters.Add("@pre_pro", SqlDbType.SmallMoney).Value = producto.pre_pro;
                    comando.Parameters.Add("@id_productor", SqlDbType.Int).Value = producto.id_productor;
                    comando.Parameters.Add("@img_pro", SqlDbType.VarChar, 200).Value = (object)producto.img_pro ?? DBNull.Value;
                    comando.Parameters.Add("@estado", SqlDbType.Char, 1).Value = producto.estado;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            string sql = "update Productos set nom_pro = @nom_pro, id_tipo = @id_tipo, pre_pro = @pre_pro, id_productor = @id_productor, img_pro = @img_pro, estado = @estado where id_pro = @id_pro";

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cnx))
                {
                    con.Open();

                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        comando.Parameters.Add("@nom_pro", SqlDbType.VarChar, 25).Value = producto.nom;
                        comando.Parameters.Add("@id_tipo", SqlDbType.Int).Value = producto.id_tipo;
                        comando.Parameters.Add("@pre_pro", SqlDbType.SmallMoney).Value = producto.pre_pro;
                        comando.Parameters.Add("@id_productor", SqlDbType.Int).Value = producto.id_productor;
                        comando.Parameters.Add("@img_pro", SqlDbType.VarChar, 200).Value = (object)producto.img_pro ?? DBNull.Value;
                        comando.Parameters.Add("@estado", SqlDbType.Char, 1).Value = producto.estado;
                        comando.Parameters.Add("@id_pro", SqlDbType.Int).Value = producto.id_productor;
                        comando.ExecuteNonQuery();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                string res = ex.Message;
                // Manejo de excepciones aquí
            }
        }

        public static void EliminarProducto(Producto producto)
        {
            string sql = "DELETE FROM productos WHERE id_pro = @id_pro";

            using (SqlConnection con = new SqlConnection(Conexion.cnx))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    comando.Parameters.Add("@id_pro", SqlDbType.Int).Value = producto.id_productor;
                    comando.ExecuteNonQuery();
                }

                con.Close();
            }
        }
    }
}

 