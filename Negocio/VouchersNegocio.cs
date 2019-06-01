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
    public class VouchersNegocio
    {
        public List<Vouchers> listarVouchers()
        {
            List<Vouchers> listado = new List<Vouchers>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Vouchers voucher;
            try
            {
                accesoDatos.setearConsulta("SELECT  ID, CODIGOVOUCHER, ESTADO FROM VOUCHERS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    voucher = new Vouchers();
                    voucher.Id = (int)accesoDatos.Lector["ID"];
                   voucher.CodigoVoucher = accesoDatos.Lector["CODIGOVOUCHER"].ToString();
                   voucher.Estado = (bool)accesoDatos.Lector["ESTADO"];
                    listado.Add(voucher);
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

        public void modificarVoucher(Vouchers modificar)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update VOUCHERS Set Estado=@Estado, IDCLIENTE=@IdCliente, IDPRODUCTO=@IdProducto Where Id=" + modificar.Id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", modificar.Estado);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCliente", modificar.cliente.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdProducto", modificar.producto.Id);
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
