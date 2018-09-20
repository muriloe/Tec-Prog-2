using SistemaCursos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursos.Model
{
    class Periodo: IImpressao
    {
        public int numeroIdentificacao { get; set; }
        public List<Disciplina> disciplinas { get; set; }

        public Periodo()
        {
            disciplinas = new List<Disciplina>();
        }

        public bool cadastraPeriodo(int numIdentificacao)
        {
            this.numeroIdentificacao = numIdentificacao;
            return true;
        }

        public bool adicionaDisciplina(Disciplina disciplina)
        {
            this.disciplinas.Add(disciplina);
            return true;
        }

        public void Imprimir()
        {
            Console.WriteLine(numeroIdentificacao + "° Período");
        }

        public List<Disciplina> getDisciplinas()
        {
            return disciplinas;
        }
    }
}
