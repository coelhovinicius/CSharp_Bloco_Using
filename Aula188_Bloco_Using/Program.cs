/* BLOCO USING - Sintaxe simplificada que garante que os objetos IDisposable serao fechados.
 *  - Objetos do IDisposable nao sao gerenciados pelo CLR. Eles precisam ser manualmente fechados. Por exemplo: Font, Filestream,
 *    StreamReader, StreamWriter, etc..
 */

/*>>> PROGRAMA PRINCIPAL <<< */
using System;
using System.IO;

namespace Aula188_Bloco_Using
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\filex.txt"; // Caminho do arquivo

            try // Bloco TRY/CATCH utilizado para Tratamento de Erros
            {
                /* // Bloco "using" - Tudo o que este bloco contiver sera automaticamente fechado
                using (FileStream fs = new FileStream(path, FileMode.Open))
                { */
                // using (StreamReader sr = new StreamReader(fs)) // "sr" recebe os dados de "fs"
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream) // Enquanto houver linhas na stream (no arquivo .txt)
                    {
                        string line = sr.ReadLine(); // Le a linha
                        Console.WriteLine(line); // Imprime a linha na tela
                    }
                }
                // }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
