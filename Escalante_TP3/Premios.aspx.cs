using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escalante_TP3
{
    public partial class Premios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Silla_Click(object sender, EventArgs e)
        {
            string VoucherId;
            VoucherId = Request.Params["VoucherId"];
            int id = 1;
            Response.Redirect("~/Datos.aspx?codigo=" + VoucherId + "&idprod="+id);
        }

        protected void Placa_Click(object sender, EventArgs e)
        {
            string VoucherId;
            VoucherId = Request.Params["VoucherId"];
            int id = 2;
            Response.Redirect("~/Datos.aspx?codigo=" + VoucherId + "&idprod=" + id);
        }

        protected void Procesador_Click(object sender, EventArgs e)
        {
            string VoucherId;
            VoucherId = Request.Params["VoucherId"];
            int id = 3;
            Response.Redirect("~/Datos.aspx?VoucherId=" + VoucherId + "&idprod=" + id);
        }
    }
}