using SistemaCursos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursos.Model
{
    class Disciplina: IImpressao
    {
        
        private int codigo { get; set; }
        private string nome { get; set; } 
        private int numeroAulasTeoricas { get; set; }
        private int numeroAulasPraticas { get; set; }
        private int numeroCreditos { get; set; }
        private int totalHorasAulas { get; set; }
        private int totalHorasRelogio { get; set; }
        private List<String> preRequisitos { get; set; }

        public Disciplina()
        {
            preRequisitos = new List<String>();
        }

        public bool cadastrarDisciplina(int codigo, string nome, int numAulaTeoricas, int numAulasPraticas, 
                                        int numCredito, int totalHorasAulas, int totalHorasRelogio){
                this.codigo = codigo;
                this.nome = nome;
                this.numeroAulasTeoricas = numAulaTeoricas;
                this.numeroAulasPraticas = numAulasPraticas;
                this.numeroCreditos = numCredito;
                this.totalHorasAulas = totalHorasAulas;
                this.totalHorasRelogio = totalHorasRelogio;

                return true;
        }

        public bool adicionarPreRequisito(String disciplina)
        {
            this.preRequisitos.Add(disciplina);
            return true;
        }

        public void Imprimir()
        {
            string requisitos = "";
            string requisitosLimitado = "";
            string nomeLimitado = "";
            foreach (String materia in preRequisitos)
            {
                requisitos = requisitos + " " + materia;
            }
            if (requisitos.Length > 24)
            {
                requisitosLimitado = requisitos.Substring(0, 23);
            }
            else
            {
                int tamanhoReq = requisitos.Length;
                int espacosVazios = 23 - tamanhoReq;
                requisitosLimitado = requisitos.PadRight(23);

            }


            if (nome.Length > 40)
            {
                nomeLimitado = nome.Substring(0, 39);
            }
            else
            {
                int tamanhoNome = nome.Length;
                int espacosVazios = 39 - tamanhoNome;
                nomeLimitado = nome.PadRight(39);

            }
            Console.WriteLine("|"+codigo + "\t|" + nomeLimitado + "|" + requisitosLimitado + "|" + numeroAulasTeoricas 
                                + "\t|" + numeroAulasPraticas + "\t|" + numeroCreditos + "\t|" +
                                totalHorasAulas + "\t|" + totalHorasRelogio + "|");
        }
    }
}
