using SistemaCursos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursos.Model
{
    delegate void HRModificadoEventHandler(Disciplina d, int horarioAntigo, int horarioNovo);

    class Disciplina: IImpressao
    {
        
        public int codigo { get; set; }
        public string nome { get; set; }
        public int numeroAulasTeoricas { get; set; }
        public int numeroAulasPraticas { get; set; }
        public int numeroCreditos { get; set; }
        public int totalHorasAulas { get; set; }
      
        private int _totalHorasRelogio;
        public int totalHorasRelogio
        {
            get
            {
                return _totalHorasRelogio;
            }
            set
            {
                if (alteracaoHRFinalizado != null)
                {
                    int horaAntiga = _totalHorasRelogio;
                    int novaHR = value;
                    _totalHorasRelogio = novaHR;
                    alteracaoHRFinalizado(this, horaAntiga, novaHR);
                }
                else
                {
                    _totalHorasRelogio = value;
                }
            }
        }
        public List<String> preRequisitos { get; set; }
        public event HRModificadoEventHandler alteracaoHRFinalizado;




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
