using SistemaCursos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursos.Model
{
    class Curso: IImpressao
    {
        public string Nome { get; set; }
        public List<Periodo> Periodos { get; set; }

        public Curso()
        {
            Periodos = new List<Periodo>();
        }

        public bool cadastrarCurso(string nome)
        {
            Nome = nome;
            return true;
        }

        public bool inserirPeriodo (Periodo periodo)
        {
            Periodos.Add(periodo);
            return true;
        }

        public void Imprimir()
        {
            Console.WriteLine("\t\t\t Matriz – " + Nome );
        }
    }
}
