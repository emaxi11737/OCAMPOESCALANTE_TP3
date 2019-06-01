using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class ProductosNegocio
    {
        public List<Productos> listarProductos()
        {
            List<Productos> listado = new List<Productos>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Productos producto;
            try
            {
                accesoDatos.setearConsulta("SELECT ID, TITULO, DESCRIPCION FROM PRODUCTOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    producto = new Productos();
                    producto.Id = (int)accesoDatos.Lector["ID"];
                    producto.Titulo = accesoDatos.Lector["TITULO"].ToString();
                    producto.Descripcion = accesoDatos.Lector["DESCRIPCION"].ToString();
                    listado.Add(producto);
                }

                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
