using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursos.Model
{
    class Periodo
    {
        private int numeroIdentificacao { get; set; }
        private List<Disciplina> disciplinas { get; set; }

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
    }
}
