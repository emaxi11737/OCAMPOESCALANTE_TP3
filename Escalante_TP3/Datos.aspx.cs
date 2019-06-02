using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Net.Mail;
using System.Net;

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
            while (i < count)
            {
                int r = listClientesLocal[i].DNI;
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
                    while (i < count)
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
                voucher.cliente = new Clientes();
                voucher.producto = new Productos();
                string idVoucher = (string)Session["idVoucher"];
                voucher.Id = Convert.ToInt32(idVoucher);
                int idP;
                idP = Convert.ToInt32(Request.Params["idprod"]);

                cliente.DNI = Convert.ToInt32(txtDNI.Text);
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.Direccion = txtDireccion.Text;
                if (correcto == true)
                {
                    cliente.Id = i + 1;
                    clientesNegocio.modificarCliente(cliente);
                }
                else
                {
                    clientesNegocio.agregarCliente(cliente);
                    cliente.Id = listClientesLocal.Count() + 1;
                }
                voucher.Estado = true;
                voucher.cliente.Id = cliente.Id;
                voucher.producto.Id = idP;
                vouchersNegocio.modificarVoucher(voucher);
                enviarMail(cliente.Email,cliente.Nombre,voucher.CodigoVoucher);
                Response.Write("<script>alert('Guardado correctamente!!');</script>");
                Response.Redirect("index.aspx");

            }
        }

        private void enviarMail(string email,string nombre,string codigoVoucher)
        {
            string to = email;

            //It seems, your mail server demands to use the same email-id in SENDER as with which you're authenticating. 
            //string from = "sender@domain.com";
            string from = "mescalante@aserraderogottert.com.ar";

            string subject = "Sorteo Gamer";
            string body = "Hola "+nombre+",ya estas participando del sorteo !  Podras ver si ganaste el 30 de junio a las 16:00 hs";
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("mail.aserraderogottert.com.ar");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("mescalante@aserraderogottert.com.ar", "TtT654321TtT");
            client.Send(message);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
    
        }
    }
}