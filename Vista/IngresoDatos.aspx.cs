using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using Microsoft.Ajax.Utilities;
using Modelo;

namespace Vista
{
    public partial class IngresoDatos : System.Web.UI.Page
    {

        private ControladorFormulario controladorFormulario = new ControladorFormulario();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {

            try
            {
                Formulario formulario = new Formulario
                {
                    Dni = txtDni.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Ciudad = txtCiudad.Text.Trim(),
                    CP = txtCP.Text.Trim(),
                    AceptaTerminos = cbTerminos.Checked
                };

                if (controladorFormulario.ValidarFormulario(formulario))
                {
                    // Aca deberia tirar un cartelito de que ya estas participando por el premio
                }
                else
                {
                    lblMensaje.Text = "Faltan cargar datos o hay errores en el formulario.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        protected void btnValidarDni_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            lblValidacionDni.Text = string.Empty; // Limpiar mensaje previo

            if (Page.IsValid) 
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
                    lblValidacionDni.Text = "¡Ya estás registrado!";
                    lblValidacionDni.ForeColor = System.Drawing.Color.Green;
                }
                else if(dni.IsNullOrWhiteSpace())
                {
                    lblValidacionDni.Text = "¡Debes ingresar un numero de DNI!";
                    lblValidacionDni.ForeColor = System.Drawing.Color.Red;
                }

                else
                {
                    lblValidacionDni.Text = "No estas registrado, completa los datos...";
                    lblValidacionDni.ForeColor = System.Drawing.Color.Red;
                }
            }
        }


        protected void CustomValidatorDni_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string dni = args.Value.Trim();
            if (string.IsNullOrEmpty(dni) || dni.Length > 8 || !dni.All(char.IsDigit))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }


    }
}