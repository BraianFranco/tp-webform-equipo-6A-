using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorImagen
    {

        public AccesoDatos db;
        public Imagen imagen;
     

        public ControladorImagen() { 
        
            db = new AccesoDatos();
            imagen = new Imagen();
       

        }

        public Imagen getImagenByArticuloId(int id)
        {

           

            try
            {

                
                db.setearConsulta("SELECT Id, IdArticulo,ImagenUrl FROM IMAGENES where IdArticulo = @IdArt");

                db.setearParametro("IdArt",id);

                db.ejecutarLectura();

                if (db.Lector.Read())
                {              
                    imagen.Id = (int)db.Lector["Id"]; 
                    imagen.IdArticulo = (int)db.Lector["IdArticulo"];
                    imagen.Url = db.Lector["ImagenUrl"].ToString();
                }

                return imagen;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally
            {

                db.cerrarConexion();

            }




        }





    }
}
