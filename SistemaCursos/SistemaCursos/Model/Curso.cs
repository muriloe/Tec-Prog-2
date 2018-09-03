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
        private string nome { get; set; }
        private List<Periodo> periodos { get; set; }

        public Curso()
        {
            periodos = new List<Periodo>();
        }

        public bool cadastrarCurso(string nome)
        {
            this.nome = nome;
            return true;
        }

        public bool inserirPeriodo (Periodo periodo)
        {
            this.periodos.Add(periodo);
            return true;
        }

        public void Imprimir()
        {
            throw new NotImplementedException();
        }
    }
}
