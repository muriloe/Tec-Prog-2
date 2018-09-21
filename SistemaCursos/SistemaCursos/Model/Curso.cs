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
        public static string Nome { get; set; }
        private static List<Periodo> _Periodos;
        public List<Periodo> Periodos
        {
            get { return _Periodos; }
            set { _Periodos = value; }
        }
        private static int _AT;
        public static int AT
        {
            get { return _AT; }
            set { _AT = value; }
        }
        private static int AP { get; set; }
        private static int CRED { get; set; }
        private static int HA { get; set; }
        private static int HR { get; set; }

        public Curso()
        {
            Periodos = new List<Periodo>();
        }

        public void HRChange(Disciplina d, int horarioAntigo, int horarioNovo)
        {
            Console.WriteLine("A disciplina " + d.nome +  " teve sua carga horária modificada de "+ horarioAntigo + " para " + horarioNovo);
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
            
            string linhaSoma;
            try
            {
                Console.WriteLine("\t\t\t Matriz – " + Nome);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Curso não instanciado");
       
            }
            List<Periodo> periodos = this.Periodos;

            foreach (Periodo p in periodos)
            {
                try
                {
                    p.Imprimir();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Periodo não instanciado");
                }

                List<Disciplina> disciplinas = p.disciplinas;
                Console.WriteLine("|Ordem\t|" + "Disciplina                             |" + "Requisitos             |" + "AT\t|"
                                  + "AP\t|" + "CRED\t|" + "HA \t|" + "HR|");
                foreach (Disciplina d in disciplinas)
                {
                    try
                    {
                        d.Imprimir();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Materia nao instaciada");
                    }

                }
                linhaSoma = "TOTAL\t\t AT:" + SomarHorasPeriodo("AT", p);
                p.AT = SomarHorasPeriodo("AT", p);
                linhaSoma += "\t AP:" + SomarHorasPeriodo("AP", p);
                p.AP = SomarHorasPeriodo("AP", p);
                linhaSoma += "\t CRED:" + SomarHorasPeriodo("CRED", p);
                p.CRED = SomarHorasPeriodo("CRED", p);
                linhaSoma += "\t HA:" + SomarHorasPeriodo("HA", p);
                p.HA = SomarHorasPeriodo("HA", p);
                linhaSoma += "\t HR:" + SomarHorasPeriodo("HR", p);
                p.HR = SomarHorasPeriodo("HR", p);
                Console.WriteLine(linhaSoma);
                Console.WriteLine("\n\n");
            }
            somarPeriodos();
            Console.WriteLine(Nome + " - TOTAL: \t\t HA: " + HA +"\tHR: " + HR + "\tCRED:" + CRED + "\tAT: " + AT +"\tAP:" + AP);
        }

        static void somarPeriodos()
        {
            foreach (Periodo p in _Periodos) {
                HA += p.HA;
                HR += p.HR;
                CRED += p.CRED;
                AT += p.AT;
                AP += p.AP;
            }
        }

        static int SomarHorasPeriodo(string atributo, Periodo periodo)
        {
            List<Disciplina> displinas = periodo.disciplinas;
            int soma = 0;
            foreach (Disciplina d in displinas)
            {
                if (atributo == "AT")
                {
                    AT = soma;
                    soma += d.numeroAulasTeoricas;
                }
                else if (atributo == "AP")
                {
                    soma += d.numeroAulasPraticas;
                }
                else if (atributo == "CRED")
                {
                    soma += d.numeroCreditos;
                }
                else if (atributo == "HA")
                {
                    soma += d.totalHorasAulas;
                }
                else if (atributo == "HR")
                {
                    soma += d.totalHorasRelogio;
                }
            }


            return soma;
        }
    }
}
