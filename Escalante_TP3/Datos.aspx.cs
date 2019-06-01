using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Escalante_TP3
{
    public partial class Datos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            ClientesNegocio clientesNegocio = new ClientesNegocio();
            List<Clientes> listClientesLocal;
            listClientesLocal = clientesNegocio.listarClientes();
            int count = listClientesLocal.Count();
            bool correcto = false;
            int i = 0;
                while(listClientesLocal[i].Id < count)
                {
                    if (listClientesLocal[i].DNI.ToString() == txtDNI.Text)
                    {
                        correcto = true;
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            if (correcto == true)
            {
                txtNombre.Text = listClientesLocal[i].Nombre;
                txtApellido.Text = listClientesLocal[i].Apellido;
                txtEmail.Text = listClientesLocal[i].Email;
                txtDireccion.Text = listClientesLocal[i].Direccion;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtEmail.Text == "" || txtDireccion.Text == "")
            {
                Response.Write("<script>alert('Tienen que estar todos los campos completos!!');</script>");
            }
            else
            {
                ClientesNegocio clientesNegocio = new ClientesNegocio();
                VouchersNegocio vouchersNegocio = new VouchersNegocio();
                List<Clientes> listClientesLocal;
                listClientesLocal = clientesNegocio.listarClientes();
                int count = listClientesLocal.Count();
                bool correcto = false;
                int i = 0;
                try
                {
                    while (listClientesLocal[i].Id < count)
                    {
                        if (listClientesLocal[i].DNI.ToString() == txtDNI.Text)
                        {
                            correcto = true;
                            break;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("PaginaError.aspx");

                }
                Clientes cliente = new Clientes();
                Vouchers voucher = new Vouchers();

                voucher.Id = Convert.ToInt32(Request.Params["VoucherId"]);
                int idP;
                idP = Convert.ToInt32(Request.Params["idprod"]);

                cliente.DNI = Convert.ToInt32(txtDNI.Text);
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.Direccion = txtDireccion.Text;
                if (correcto == true)
                {
                    cliente.Id = i;
                    clientesNegocio.modificarCliente(cliente);
                }
                else
                {
                    clientesNegocio.agregarCliente(cliente);
                }
                voucher.Estado = true;
                voucher.cliente.Id = i;
                voucher.producto.Id = idP;
                vouchersNegocio.modificarVoucher(voucher);

                Response.Write("<script>alert('Guardado correctamente!!');</script>");
                Response.Redirect("index.aspx");
            }
        }
    }
}