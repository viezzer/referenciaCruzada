using System;
using System.IO;

namespace refCruzada
{
    public static class LeitorDeArquivo
    {
        public static string[] getPalavras(string caminhoDoArquivo){
            string texto = File.ReadAllText(caminhoDoArquivo);
            string[] palavras = texto.Split(new[] {' ', ',', '.', '!', '?', '/', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return palavras;
        }
    }
}

