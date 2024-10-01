using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Microsoft.Ajax.Utilities;
using Modelo;

namespace Vista
{
    public partial class _Default : Page
    {
        private ControladorVoucher controladorVoucher;


        protected void Page_Load(object sender, EventArgs e)
        {
            controladorVoucher = new ControladorVoucher();

        }





        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string codVoucher = txtVoucherCode.Text.Trim();

            try
            {
                if (codVoucher.IsNullOrWhiteSpace())
                {
                    /// tirar algun mensaje para que ingrese datos

                    lblMensaje.Text = "Por favor, ingrese un Código.";
                    lblMensaje.Visible = true;

                }
                else
                {

                    if (controladorVoucher.VoucherEsValido(codVoucher))
                    {
                        Response.Redirect($"SelecciónPremio.aspx?cod={codVoucher}");
                    }
                    else
                    {
                        /// lanzar cartel de no existe el voucher o fue usado                

                        lblMensaje.Text = "El Código no existe o ya fue utilizado.";
                        lblMensaje.Visible = true;

                   

                    }


                }

            }
            catch (Exception ex) { throw ex; }


        }

       


    }
}