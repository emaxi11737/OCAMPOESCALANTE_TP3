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
    public class ClientesNegocio
    {
        public List<Clientes> listarClientes()
        {
            List<Clientes> listado = new List<Clientes>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Clientes cliente;
            try
            {
                accesoDatos.setearConsulta("SELECT IDCLIENTE,DNI, NOMBRE, APELLIDO, EMAIL, DIRECCION FROM CLIENTES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    cliente = new Clientes();
                    cliente.Id = (int)accesoDatos.Lector["IDCLIENTE"];
                    cliente.DNI = (int)accesoDatos.Lector["DNI"];
                    cliente.Nombre = accesoDatos.Lector["NOMBRE"].ToString();
                    cliente.Apellido = accesoDatos.Lector["APELLIDO"].ToString();
                    cliente.Email = accesoDatos.Lector["EMAIL"].ToString();
                    cliente.Direccion = accesoDatos.Lector["DIRECCION"].ToString();
                    listado.Add(cliente);
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

        public void agregarCliente(Clientes nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearSP("SP_AGREGARCLIENTE");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", nuevo.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Email", nuevo.Email);
                accesoDatos.Comando.Parameters.AddWithValue("@Direccion", nuevo.Direccion);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();

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

        public void modificarCliente(Clientes modificar)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update CLIENTES Set DNI=@DNI,Nombre=@Nombre,Apellido=@Apellido,Email=@email,Direccion=@direccion Where IdCliente=" + modificar.Id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", modificar.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modificar.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Email", modificar.Email);
                accesoDatos.Comando.Parameters.AddWithValue("@Direccion", modificar.Direccion);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
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
