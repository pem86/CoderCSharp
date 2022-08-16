using PrimeraEntregaProyectoFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntregaProyectoFinal.ADO.NET
{
    public class ProductoHandler : DbHandler
    {
        public List<Producto> TraerProductos(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SELECT * FROM Producto WHERE IdUsuario = @idUsuario;";
                    sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                    
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();

                                producto.id = Convert.ToInt32(dataReader["Id"]);
                                producto.descripcion = dataReader["Descripciones"].ToString();
                                producto.costo = Convert.ToDouble(dataReader["Costo"]);
                                producto.precioVenta = Convert.ToDouble(dataReader["PrecioVenta"]);
                                producto.stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.idUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                                productos.Add(producto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return productos;
        }
    }
}
