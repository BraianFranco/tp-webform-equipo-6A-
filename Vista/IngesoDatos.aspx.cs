using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Modelo;

namespace Vista
{
    public partial class IngesoDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {

        }

        protected void btnValidarDni_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            if (!string.IsNullOrEmpty(dni))
            {
                ControladorCliente controlador = new ControladorCliente();
                Cliente cliente = controlador.ObtenerPorDni(dni);

                if (cliente != null)
                {
                    
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtDireccion.Text = cliente.Direccion;
                    txtEmail.Text = cliente.Email;
                    txtCiudad.Text = cliente.Ciudad;
                    txtCP.Text = cliente.CP.ToString();
                }
                else
                {
                    // Deberia poner algo si no existe el dni??
                }
            }
        }



    }
}