﻿using Modelo;
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

        public Cliente ObtenerPorDni(string dni)
        {
            Cliente cliente = null;
            AccesoDatos Ad = new AccesoDatos();

            Ad.setearConsulta("select Id, Documento, Nombre , Apellido , Email , Direccion , Ciudad ,CP from Clientes where Documento = @DNI");
            Ad.setearParametro("@DNI", dni);

            try
            {
                Ad.ejecutarLectura();

                if (Ad.Lector.Read())
                {
                    cliente = new Cliente
                    {
                        Id = (int)Ad.Lector["Id"],
                        Documento = (string)Ad.Lector["Documento"],
                        Nombre = (string)Ad.Lector["Nombre"],
                        Apellido = (string)Ad.Lector["Apellido"],
                        Ciudad = (string)Ad.Lector["Ciudad"],
                        Email = (string)Ad.Lector["Email"],
                        Direccion = (string)Ad.Lector["Direccion"],
                        CP = (int)Ad.Lector["CP"]
                    };
                }
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }

            return cliente;
        }

        public bool ClienteExiste(string dni)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("select count(*) from Clientes where Documento = @DNI");
            Ad.setearParametro("@DNI", dni);

            try
            {
                Ad.ejecutarLectura();
                if (Ad.Lector.Read())
                {
                    return (int)Ad.Lector[0] > 0;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }

            return false;
        }

        public void InsertarCliente(Cliente cliente)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("insert into Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) values (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");
            Ad.setearParametro("@Documento", cliente.Documento);
            Ad.setearParametro("@Nombre", cliente.Nombre);
            Ad.setearParametro("@Apellido", cliente.Apellido);
            Ad.setearParametro("@Email", cliente.Email);
            Ad.setearParametro("@Direccion", cliente.Direccion);
            Ad.setearParametro("@Ciudad", cliente.Ciudad);
            Ad.setearParametro("@CP", cliente.CP);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }
        }

        public int ObtenerIdCliente(Cliente cliente)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("Select Id from clientes where Documento = @dni");
            Ad.setearParametro("@dni", cliente.Documento);

            try
            {
                Ad.ejecutarLectura(); 

                if (Ad.Lector.Read())
                {
                    return (int)Ad.Lector["Id"];
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Ad.cerrarConexion();
            }
        }

        public void ActualizarVoucher(string codigoVoucher, int idCliente, DateTime fechaCanje, int idArticulo)
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher");
            Ad.setearParametro("@CodigoVoucher", codigoVoucher);
            Ad.setearParametro("@IdCliente", idCliente);
            Ad.setearParametro("@FechaCanje", fechaCanje);
            Ad.setearParametro("@IdArticulo", idArticulo);

            try
            {
                Ad.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { Ad.cerrarConexion(); }
        }

        public int ObtenerMaxIdCliente()
        {
            AccesoDatos Ad = new AccesoDatos();
            Ad.setearConsulta("SELECT MAX(Id) FROM Clientes");

            try
            {
                Ad.ejecutarLectura();
                if (Ad.Lector.Read())
                {
                    return Ad.Lector.IsDBNull(0) ? 0 : Ad.Lector.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Ad.cerrarConexion();
            }

            return 0;
        }



    }
}
