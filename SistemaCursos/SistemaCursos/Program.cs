using SistemaCursos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursos
{
    class Program
    {
        static Curso c1;

        static void Main(string[] args)
        {

            //MainMenu();
            //Teste();
            Leitura();
            c1.Imprimir();
            AlterarDisciplina();

        }


        static public void MainMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n" +
                              "1. LER XML\n" + 
                              "2. IMPRIMIR CURSO\n" + 
                              "Digite a opcao:");
            string line = Console.ReadLine();
            int selecao = 0;
            try
            {
                selecao = Convert.ToInt16(line);
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor digitado inválido");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Número muito grande");
            }
            catch (Exception)
            {
                Console.WriteLine("Valor digitado inválido");
            }
            finally
            {
                MainMenu();
            }
            

        }

        static private void AlterarDisciplina()
        {
            try
            {
                c1.Periodos[0].disciplinas[0].alteracaoHRFinalizado += c1.HRChange;
                c1.Periodos[0].disciplinas[0].totalHorasRelogio = 39;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Referencia de objeto inválida");
            }
            

        }

        static public void Leitura()
        {
            c1 = null;
            string diretorio = @"C:\temp\";
            string parametro1 = "MatrizCurricularBSI.txt";
            string parametro2 = "MatrizCurricularBSI.xml";
            string parametro3 = "BSI";
            IOFiles.converteTXTparaXML(diretorio + parametro1, diretorio + parametro2, parametro3);
            c1 = ImportadorXML.ImportaCurso(diretorio + parametro2);
        }

        static public void Teste()
        {
            Disciplina disciplina = new Disciplina();
            disciplina.cadastrarDisciplina(1, "Fundamento de Sistemas de Informacao", 30, 32, 15, 300, 350);

            Disciplina disciplina2 = new Disciplina();
            disciplina2.cadastrarDisciplina(2, "Pré-Calculo", 20, 0, 15, 300, 350);

            Disciplina disciplina3 = new Disciplina();
            disciplina3.cadastrarDisciplina(3, "Téc-Prog", 15, 30, 15, 200, 250);
            disciplina3.adicionarPreRequisito("1");

            Periodo p1 = new Periodo();
            p1.cadastraPeriodo(1);
            p1.adicionaDisciplina(disciplina);
            p1.adicionaDisciplina(disciplina2);

            Periodo p2 = new Periodo();
            p2.cadastraPeriodo(2);
            p2.adicionaDisciplina(disciplina3);

            Curso bsi = new Curso();
            bsi.cadastrarCurso("Bacharelado em Sistamas de Informação");
            bsi.inserirPeriodo(p1);
            bsi.inserirPeriodo(p2);
        }

        
    }
}
