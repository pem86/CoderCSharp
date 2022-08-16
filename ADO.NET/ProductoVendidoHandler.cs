using PrimeraEntregaProyectoFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraEntregaProyectoFinal.ADO.NET
{
    public class ProductoVendidoHandler : DbHandler
    {
        public List<Producto> TraerProductosVendidos(int idUsuario)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido;", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.idProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.idVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productosVendidos.Add(productoVendido);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            ProductoHandler productoHandler = new ProductoHandler();

            List<Producto> productosUsuario = new List<Producto>();

            List<Producto> productosVendidosUsuario = new List<Producto>();

            productosUsuario = productoHandler.TraerProductos(idUsuario);

            foreach (ProductoVendido productoVendido in productosVendidos)
            {
                foreach(Producto productoUsuario in productosUsuario)
                {
                    if (productoVendido.idProducto == productoUsuario.id)
                    {
                        productoUsuario.stock = productoVendido.stock;
                        productosVendidosUsuario.Add(productoUsuario);
                    }
                }
            }

            return productosVendidosUsuario;
        }
    }
}
