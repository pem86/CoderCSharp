using PrimeraEntregaProyectoFinal.ADO.NET;
using PrimeraEntregaProyectoFinal.Modelos;

namespace PrimeraEntregaProyectoFinal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UsuarioHandler usuarioHandler = new UsuarioHandler();

            string nombreUsuario = "tcasazza";

            Console.WriteLine("Consulta de datos del usuario '{0}'", nombreUsuario);
            Console.WriteLine("Nombre: {0} / Apellido: {1} / Mail: {2}", usuarioHandler.TraerUsuario(nombreUsuario).nombre, usuarioHandler.TraerUsuario(nombreUsuario).apellido, usuarioHandler.TraerUsuario(nombreUsuario).mail);
            Console.WriteLine("-----------------------------------------------------------");


            ProductoHandler productoHandler = new ProductoHandler();

            int idUsuarioProducto = 1;

            List<Producto> productosUsuario = new List<Producto>();

            productosUsuario = productoHandler.TraerProductos(idUsuarioProducto);

            Console.WriteLine("Consulta de productos cargados del idUsuario = {0}", idUsuarioProducto);
            foreach (Producto producto in productosUsuario)
            {
                Console.WriteLine("Descripción: {0} / Costo: {1} / PrecioVenta: {2} / Stock: {3}", producto.descripcion, producto.costo, producto.precioVenta, producto.stock);
            }
            Console.WriteLine("-----------------------------------------------------------");



            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

            int idUsuarioVendido = 1;

            List<Producto> productosVendidos = new List<Producto>();

            productosVendidos = productoVendidoHandler.TraerProductosVendidos(idUsuarioVendido);

            Console.WriteLine("Consulta de productos vendidos del idUsuario = {0}", idUsuarioVendido);
            foreach (Producto producto in productosVendidos)
            {
                Console.WriteLine("Descripción: {0} / Stock: {1}", producto.descripcion, producto.stock);
            }
            Console.WriteLine("-----------------------------------------------------------");



            string nombreUsuarioLogin = "tcasazza";
            string contraseniaLogin = "SoyTobiasCasazza";

            Usuario usuarioLogin = new Usuario();

            usuarioLogin = usuarioHandler.IniciarSesion(nombreUsuarioLogin, contraseniaLogin);

            Console.WriteLine("Inicio de sesión correcto del usuario '{0}' devuelve los datos.", nombreUsuario);
            Console.WriteLine("Id: {0} / Nombre: {1} / Apellido: {2} / Mail: {3}", usuarioLogin.id, usuarioLogin.nombre, usuarioLogin.apellido, usuarioLogin.mail);
            Console.WriteLine("-----------------------------------------------------------");

            contraseniaLogin = "ContraseñaIncorrecta";

            usuarioLogin = usuarioHandler.IniciarSesion(nombreUsuarioLogin, contraseniaLogin);

            Console.WriteLine("Inicio de sesión incorrecto del usuario '{0}' devuelve el id en 0 y sin datos.", nombreUsuario);
            Console.WriteLine("Id: {0} / Nombre: {1} / Apellido: {2} / Mail: {3}", usuarioLogin.id, usuarioLogin.nombre, usuarioLogin.apellido, usuarioLogin.mail);
            Console.WriteLine("-----------------------------------------------------------");

        }
    }
}