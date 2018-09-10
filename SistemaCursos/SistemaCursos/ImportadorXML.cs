using SistemaCursos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SistemaCursos
{
    class ImportadorXML
    {
        public static void ImportaCurso(string arquivoXML)
        {
            Curso novoCurso = new Curso();
            Periodo novoPeriodo = new Periodo();
            Disciplina novaDisciplina = new Disciplina();


            XmlTextReader reader = new XmlTextReader(arquivoXML);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.Name == "Curso")
                        {
                            novoCurso.cadastrarCurso(reader.GetAttribute("nome"));
                        }
                        if (reader.Name == "periodo")
                        {
                            novoPeriodo = new Periodo();   
                            string numPeriodo = reader.GetAttribute("numero");
                            numPeriodo = numPeriodo.Replace("º", "");
                            int numero = System.Convert.ToInt32(numPeriodo);
                            novoPeriodo.cadastraPeriodo(numero);
                            novoCurso.inserirPeriodo(novoPeriodo);
                        }
                        if (reader.Name == "disciplina")
                        {
                            novaDisciplina = new Disciplina();
                            novaDisciplina.cadastrarDisciplina(Convert.ToInt32(reader.GetAttribute("Ordem")),
                                                                               reader.GetAttribute("Disciplinas"),
                                                                               Convert.ToInt32(reader.GetAttribute("AT")),
                                                                               Convert.ToInt32(reader.GetAttribute("AP")),
                                                                               Convert.ToInt32(reader.GetAttribute("Créd.")),
                                                                               Convert.ToInt32(reader.GetAttribute("HA")),
                                                                               Convert.ToInt32(reader.GetAttribute("HR")));

                            novoPeriodo.adicionaDisciplina(novaDisciplina);
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element.
                        break;
                }
            }
            Console.WriteLine(novoCurso);
        }

    }
}