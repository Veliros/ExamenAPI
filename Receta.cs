using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace examen.Models
{
    public class Receta
    {
        // Variables:
        public int id { get; set; }
        public string titulo { get; set; }
        public string comentarios { get; set; }
        public int dificultad { get; set; }

        // Constructor:
        public Receta(int id, string titulo, string comentarios, int dificultad)
        {
            this.id = id;
            this.titulo = titulo;
            this.comentarios = comentarios;
            this.dificultad = dificultad;
        }
    }
}