using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursos.Model
{
    class Faculdade
    {
        private List<Curso> cursos { get; set; }

        public Faculdade()
        {
            cursos = new List<Curso>();
        }
    }

}
