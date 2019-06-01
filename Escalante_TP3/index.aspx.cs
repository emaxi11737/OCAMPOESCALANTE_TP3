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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            VouchersNegocio vouchersNegocio = new VouchersNegocio();
            List<Vouchers> listVouchersLocal;
            listVouchersLocal = vouchersNegocio.listarVouchers();
            bool correcto1 = false, correcto2 = false;
            int i = 0;
            try
            {
                while (listVouchersLocal[i].Id!=-1)
                {
                    if (listVouchersLocal[i].CodigoVoucher == txtcodigoV.Text)
                    {
                        correcto1 = true;
                        if(listVouchersLocal[i].Estado==false)
                        {
                            correcto2 = true;
                        }
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
                if(correcto1==true)
                {
                    Response.Redirect("ErrorUsado.aspx");
                }
                else
                {
                    Response.Redirect("PaginaError.aspx");
                }
                
            }
            if(correcto2==true) Response.Redirect("~/Premios.aspx?VoucherId="+i);
        }
    }
}