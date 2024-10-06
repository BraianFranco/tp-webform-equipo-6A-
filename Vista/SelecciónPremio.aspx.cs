using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace Vista
{
    public partial class SelecciónPremio : System.Web.UI.Page
    {

        public List<Articulo> ListaPremios { get; set; }
        public List<string> ListaImagenes { get; set; }



        public string CodVoucher;
        public string CodArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
      
            ControladorArticulo ControlArticulo = new ControladorArticulo();
            ControladorImagen ControlImagen = new ControladorImagen();

            ListaPremios = ControlArticulo.Listar();
          

            if (!IsPostBack)
            {
                repetidor.DataSource = ListaPremios;
                repetidor.DataBind();
                // lo estoy suscribiendo en el aspx, nosé si subscribirlo acá también lanzará algún error
                repetidor.ItemDataBound += ItemBound;
            }
           

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
            Button btn = (Button)sender;
            string IdArticulo = btn.CommandArgument;
                      
            // Guardar en sesión

            Session.Add("codVoucher", CodVoucher);
            Session.Add("IdArticulo", IdArticulo);
        
            Response.Redirect($"IngresoDatos.aspx",false);

        }



        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            Repeater childRepeater = (Repeater)args.Item.FindControl("repetidorImagenes");

            childRepeater.DataSource = ControladorImagen.getListImagenUrlsByArticuloId(((Articulo)args.Item.DataItem).Id);

            childRepeater.DataBind();
        }



    }
}