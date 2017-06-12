using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace proyectoSemestralBiblioteca
{
    /// <summary>
    /// Descripción breve de Temperatura
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Temperatura : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola Mundo, Esto es un Web Service";
        }

        [WebMethod]
        public Double obtenerCosto(int cantidad, double precio)
        {
            return cantidad * precio;
        }

        [WebMethod]
        public List<String> obtenerNombres()
        {
            List<String> lista= new List<String>();
            using (var contexto = new Models.bibliotecaEntites())
            {
                var list = from x in contexto.Libro
                            select x;
                foreach (var item in list)
                {
                    lista.Add(item.tituloLibro);
                }
            }
            return lista;
        }


    }
}
