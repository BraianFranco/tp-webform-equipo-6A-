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

            // Verificar si los parámetros están en la sesión
            if (!IsPostBack)
            {
                if (Session["codVoucher"] == null || Session["codArticulo"] == null)
                {
                    lblMensaje.Text = "Faltan datos para completar la operación.";
                    btnParticipar.Enabled = false; // Deshabilitar el botón si faltan datos
                }
            }

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
                    ControladorCliente controladorCliente = new ControladorCliente();
                    if (!controladorCliente.ClienteExiste(formulario.Dni))
                    {
                        Cliente nuevoCliente = new Cliente
                        {
                            Documento = formulario.Dni,
                            Nombre = formulario.Nombre,
                            Apellido = formulario.Apellido,
                            Email = formulario.Email,
                            Direccion = formulario.Direccion,
                            Ciudad = formulario.Ciudad,
                            CP = int.Parse(formulario.CP)
                        };

                        controladorCliente.InsertarCliente(nuevoCliente); // insert del nuevo cliente en la BD

                        string codigoVoucher = Session["codVoucher"]?.ToString();
                        int idArticulo = (int)Session["codArticulo"];

                        DateTime fechaCanje = DateTime.Now;

                        int idCliente = controladorCliente.ObtenerMaxIdCliente();


                        controladorCliente.ActualizarVoucher(codigoVoucher, idCliente, fechaCanje, idArticulo);


                        Response.Redirect("Felicitaciones.aspx");
                    }
                    else // else solo hago el update en la tabla de vouchers
                    {

                        Cliente nuevoCliente = new Cliente
                        {
                            Documento = formulario.Dni,
                            Nombre = formulario.Nombre,
                            Apellido = formulario.Apellido,
                            Email = formulario.Email,
                            Direccion = formulario.Direccion,
                            Ciudad = formulario.Ciudad,
                            CP = int.Parse(formulario.CP)
                        };



                        string codigoVoucher = Session["codVoucher"] != null ? Session["codVoucher"].ToString() : "" ;
                        int idArticulo = (int)Session["codArticulo"];

                        int idCliente = controladorCliente.ObtenerIdCliente(nuevoCliente);

                        DateTime fechaCanje = DateTime.Now;

                        controladorCliente.ActualizarVoucher(codigoVoucher, idCliente , fechaCanje, idArticulo);

                        Response.Redirect("Felicitaciones.aspx");
                    }
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
            lblValidacionDni.Text = string.Empty; // Limpiar mensaje previo

            if (Page.IsValid)
            {
                string dni = txtDni.Text.Trim();


                lblValidacionDni.Text = string.Empty; // Limpiar mensaje previo

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
                else if (string.IsNullOrWhiteSpace(dni))
                {
                    lblValidacionDni.Text = "¡Debes ingresar un número de DNI!";
                    lblValidacionDni.ForeColor = System.Drawing.Color.Red;
                }
                else if (!long.TryParse(dni, out long dniNumerico))
                {
                    lblValidacionDni.Text = "¡El DNI debe ser un número!";
                    lblValidacionDni.ForeColor = System.Drawing.Color.Red;
                }
                else if (dniNumerico < 0) 
                {
                    lblValidacionDni.Text = "¡El DNI no puede ser un número negativo!";
                    lblValidacionDni.ForeColor = System.Drawing.Color.Red;
                }
                else if (dni.Length > 8)
                {
                    lblValidacionDni.Text = "¡El DNI no puede tener más de 8 caracteres!";
                    lblValidacionDni.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblValidacionDni.Text = "No estás registrado, completa los datos...";
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