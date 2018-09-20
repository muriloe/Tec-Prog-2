using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;


namespace SistemaCursos
{
    class IOFiles
    {

        public static bool converteTXTparaXML(string arquivoTxt, string arquivoXML, string nomeCurso)
        {
            //Verfica se o arquivo foi encontrado no diretório especificado
            if (!File.Exists(arquivoTxt))
            {
                //Caso não exista mostra o erro
                Console.WriteLine("Erro: " + "especifique aqui o erro");
                return false;
            }
            //Realiza a leitura do arquivo
            StreamReader leitor = new StreamReader(arquivoTxt, Encoding.Default);

            //Cria o nó principal para gerar o arquivo XML e instancia o nome do curso
            XmlDocument documento = new XmlDocument();
            XmlElement raiz = documento.CreateElement("Curso");
            raiz.SetAttribute("nome", nomeCurso);
            documento.AppendChild(raiz);

            //Limpa as variaveis que serao utilizadas para fazer a leitura do arquivo
            string linha = null;
            string[] atributos = null;
            XmlElement elementoPeriodo = null;

            //Loop de repeticao que le linha por linha do arquivo
            while ((linha = leitor.ReadLine()) != null)
            {
                string valor = linha.Trim();
                if (valor.EndsWith("Período"))
                {
                    elementoPeriodo = documento.CreateElement("periodo");
                    valor = valor.Replace("Período", "");
                    valor = valor.Trim();
                    elementoPeriodo.SetAttribute("numero", valor);
                    raiz.AppendChild(elementoPeriodo);
                }
                else if (valor.StartsWith("Ordem"))
                {
                    //Divide os elemento que contenha \t em uma lista,
                    //que será utilizada para instanciar o nó de disciplina
                    atributos = linha.Split('\t');
                }
                else if (valor.StartsWith("Total"))
                {
                    //Divide os elemento que contenha \t em uma lista
                    string[] colunas = valor.Split('\t');
                    //Instancia o indice inicial para 3 pois eh onde comecam os dados com valores
                    int indiceInicial = 3;
                    foreach (string coluna in colunas)
                    {
                        try
                        {
                            //Faz a conversão do valor selecionado
                            int numero = Convert.ToInt32(coluna.Trim());
                            //Insire o atributo/valor no nó período
                            elementoPeriodo.SetAttribute(atributos[indiceInicial].Trim(), numero.ToString());
                            indiceInicial++;
                        }
                        catch
                        {
                            //Caso ocorra erro na conversão
                        }
                    }
                }
                else if (valor.Length > 0)
                {
                    //Divide os elemento que contenha \t em uma lista
                    string[] valores = valor.Split('\t');
                    XmlElement elementoDisciplina = documento.CreateElement("disciplina");
                    for (int i = 0; i < valores.Length && i < atributos.Length; i++)
                    {
                        //Sete um atributo de um elemento XML com um valor
                        elementoDisciplina.SetAttribute(atributos[i].Trim(), valores[i].Trim());
                    }
                    //Adiciona o nó de dispiclina
                    elementoPeriodo.AppendChild(elementoDisciplina);
                }
            }
            //Salva o documento xml
            documento.Save(arquivoXML);
            return true;
        }
    }
}
