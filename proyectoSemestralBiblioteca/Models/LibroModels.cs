using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoSemestralBiblioteca.Models
{
    public class LibroModels
    {
        public int idLibro { get; set; }
        public string tituloLibro { get; set; }
        public int idEditorial { get; set; }
        public int idAutor { get; set; }
        public int idGenero { get; set; }
        public int numPaginas { get; set; }
        public DateTime fechaEdicion { get; set; }
        public int idCosto { get; set; }
        public string isbn { get; set; }
        public string idioma { get; set; }
        public int idEjemplar { get; set; }
        public int idEstante { get; set; }


    }
}