using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorCliente
    {


        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            AccesoDatos Ad = new AccesoDatos();

            Ad.setearConsulta("select Id, Documento, Nombre , Apellido , Email , Direccion , Ciudad ,CP from Clientes");

            try
            {

                Ad.ejecutarLectura();

                while (Ad.Lector.Read())
                {

                    Cliente aux = new Cliente();

                    aux.Id = (int)Ad.Lector["Id"];
                    aux.Documento = (string)Ad.Lector["Documento"];
                    aux.Nombre = (string)Ad.Lector["Nombre"];
                    aux.Apellido = (string)Ad.Lector["Apellido"];
                    aux.Ciudad = (string)Ad.Lector["Ciudad"];
                    aux.Email = (string)Ad.Lector["Email"];
                    aux.Direccion = (string)Ad.Lector["Direccion"];
                    aux.CP = (int)Ad.Lector["CP"];


                    lista.Add(aux);
                }

            }
            catch (Exception ex) { throw ex; }

            finally { Ad.cerrarConexion(); }

            return lista;

        }

    }
}
