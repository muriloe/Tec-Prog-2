using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursos.Model
{
    class Disciplina
    {
        
        private int codigo { get; set; }
        private string nome { get; set; } 
        private int numeroAulasTeoricas { get; set; }
        private int numeroAulasPraticas { get; set; }
        private int numeroCreditos { get; set; }
        private int totalHorasAulas { get; set; }
        private int totalHorasRelogio { get; set; }
        private List<Disciplina> preRequisitos { get; set; }

        public Disciplina()
        {
            preRequisitos = new List<Disciplina>();
        }

        public bool cadastrarDisciplina(int codigo, string nome, int numAulaTeoricas, int numAulasPraticas, 
                                        int numCredito, int totalHorasAulas, int totalHorasRelogio){
                this.codigo = codigo;
                this.nome = nome;
                this.numeroAulasTeoricas = numAulaTeoricas;
                this.numeroAulasPraticas = numeroAulasPraticas;
                this.numeroCreditos = numCredito;
                this.totalHorasAulas = totalHorasAulas;
                this.totalHorasRelogio = totalHorasRelogio;

                return true;
        }

        public bool adicionarPreRequisito(Disciplina disciplina)
        {
            this.preRequisitos.Add(disciplina);
            return true;
        }


    }
}
