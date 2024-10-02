using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace Vista
{
    public partial class SelecciónPremio : System.Web.UI.Page
    {

        public List<Articulo> ListaPremios { get; set; }
        public List<Imagen> ListaImagenes { get; set; }
        public string CodVoucher;
        protected void Page_Load(object sender, EventArgs e)
        {

            ControladorArticulo ControlArticulo = new ControladorArticulo();
            ControladorImagen ControlImagen = new ControladorImagen();

            ListaPremios = ControlArticulo.Listar();
            ListaImagenes = ControlImagen.Listar();

            if (Request.QueryString["cod"] !=null)
            {
               CodVoucher = Request.QueryString["cod"];
            }
            else
            {
                CodVoucher = "CodigoInvalido";
            }
            

        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

            Response.Redirect($"IngresoDatos.aspx?cod={CodVoucher}");
        }
    }
}