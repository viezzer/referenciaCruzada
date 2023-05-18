using System;

namespace refCruzada
{
    class Program
    {
        public static int? opcao;
        public static string? input;
        public static string caminhoDoArquivo="texto.txt";
        static void Main(string[] args)
        {
            //Lê o arquivo de texto para obter as palavras que nele contém
            string[] palavras = LeitorDeArquivo.getPalavras(caminhoDoArquivo);
            //Cria lista de palavras com o conteúdo obtido do arquivo de texto
            // ListaDePalavras wordsList = new ListaDePalavras(palavras);
            ListaDeLetras lettersList = new ListaDeLetras(palavras);

            //Mostrar menu de interação com usuário
            do
            {
                Console.WriteLine("");
                Console.WriteLine("\n---- MENU DE OPÇÕES ----");
                Console.WriteLine("1. Consultar palavra;");
                Console.WriteLine("2. Remover palavra;");
                Console.WriteLine("3. Consultar número total de palavras;");
                Console.WriteLine("4. Consultar número total de ocorrencias de palavras;");
                Console.WriteLine("5. Exibir palavras;");
                Console.WriteLine("6. Exibir palavras que comecam com determinada letra;");
                Console.WriteLine("7. Exibir palavras ordenadas por número de ocorrência;");
                Console.WriteLine("8. Exibir palavras que possuem um determinado número de ocorrência;");
                Console.WriteLine(">> Digite o número da opção desejada: ");
                
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        /*
                        CONSULTA_PALAVRA: consulta uma palavra na lista, 
                        informando seu número de ocorrências.
                        */
                        consulta_palavra(lettersList);
                        break;
                    case 2:
                        /*
                        REMOVE: remove uma palavra da lista (com suas ocorrências)
                        */
                        remove_palavra(lettersList);
                        break;
                    case 3:
                        /*
                        CONTA: retorna o número total de palavras (total de nodos da lista)
                        */
                        conta_palavras(lettersList);
                        break;
                    case 4:
                        /*
                        CONTA_OCORRÊNCIAS: retorna o número total de ocorrências das palavras da lista
                        (soma os contadores das palavras)
                        */
                        conta_ocorrencias(lettersList);
                        break;
                    case 5:
                        /*
                        EXIBE_PALAVRAS: exibe a lista das palavras (só as palavras, ou com os respectivos
                        contadores, em ordem alfabética (de A a Z) ou em ordem alfabética inversa (de Z a A)
                        de palavras (deve ter as duas opções).
                        */
                        exibe_palavras(lettersList);
                        break;
                    case 6:
                        /*
                        EXIBE_PALAVRAS_LETRA: exibe a lista das palavras da lista iniciadas por uma
                        determinada letra (só as palavras ou com contadores), em ordem alfabética (de A a Z)
                        ou em ordem alfabética inversa (de Z a A) de palavras (deve ter as duas opções).
                        */
                        exibe_palavras_letra(lettersList);
                        break;
                    case 7:
                        /*
                        EXIBE_PALAVRAS_NRO_OCORRENCIAS: exibe a lista das palavras (as palavras com
                        os respectivos contadores) em ordem decrescente de número de ocorrências, ou em
                        ordem crescente de número de ocorrências (deve ter as duas opções)
                        */
                        exibe_palavras_nro_ocorrencia(lettersList);
                        break;
                    case 8:
                        /*
                            EXIBE_PALAVRAS_NRO: exibe a lista das palavras que possuem um determinado
                            número de ocorrências informado.
                        */
                        exibe_palavras_nro(lettersList);
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida.");
                        break;
                }
            } while (opcao!=0);

            Console.WriteLine("Tchau!");
        }

        public static void consulta_palavra(ListaDeLetras lettersList)
        {
            Console.WriteLine("\n> Digite a palavra que deseja pesquisar na lista: ");
            input = Console.ReadLine();
            if(input==null || input.Length<1){
                Console.WriteLine("Palavra não encontrada");
                return;
            }

            NodeL? nodoLetra = lettersList.pesquisaLetra(input[0]); 
            if(nodoLetra==null){
                Console.WriteLine("Palavra não encontrada");
                return;
            }

            NodeP? nodoPalavra = nodoLetra.lista.pesquisaPalavra(input);
            if(nodoPalavra==null){
                Console.WriteLine("Palavra não encontrada");
                return;
            }
            Console.WriteLine("Palavra: "+nodoPalavra.palavra+" | Ocorrências: "+nodoPalavra.freq);
        }

        public static void remove_palavra(ListaDeLetras lettersList)
        {
            Console.WriteLine("\n> Digite a palavra que deseja remover da lista: ");
            input = Console.ReadLine();
            if(input!=null && input!="" && lettersList.removePalavra(input))
            {
                Console.WriteLine("Palavra '"+input+"' removida da lista");
                return;
            }
            Console.WriteLine("Palavra não encontrada na lista");
        }

        public static void conta_palavras(ListaDeLetras lettersList)
        {
            int numPalavras = lettersList.contaPalavras();
            Console.WriteLine("\nA lista possui "+numPalavras+" palavras");
        }

        public static void conta_ocorrencias(ListaDeLetras lettersList)
        {
            int numOcorrencias = lettersList.contaOcorrencias();
            Console.WriteLine("A lista possui "+numOcorrencias+" ocorrencias de palavras");
        }

        public static void exibe_palavras(ListaDeLetras lettersList)
        {
            Console.WriteLine("\n> Selecione uma ordem para exibir as palavras: ");
            Console.WriteLine("1. Normal (A-Z)");
            Console.WriteLine("2. Inversa (Z-A)");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    lettersList.exibir();
                    break;
                case 2:
                    lettersList.exibirInvertido();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        public static void exibe_palavras_letra(ListaDeLetras lettersList)
        {
            Console.WriteLine("\n> Digite uma letra: ");
            input = Console.ReadLine();
            ListaDePalavras lp = lettersList.filtraLetra(input[0]);
            if(lp!=null)
            {
                Console.WriteLine("\n> Escolha a ordem da lista: ");
                Console.WriteLine("1. Normal (A-Z)");
                Console.WriteLine("2. Inversa (Z-A)");
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        lp.showList();
                        break;
                    case 2:
                        lp.showListInvertido();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        public static void exibe_palavras_nro_ocorrencia(ListaDeLetras lettersList)
        {
            Console.WriteLine("Escolha a ordem: ");
            Console.WriteLine("1. Crescente");
            Console.WriteLine("2. Decrescente");
            int opcao = int.Parse(Console.ReadLine());
            ListaDePalavras? lp = lettersList.getPalavras();
            if(lp!=null)
            {
                lp.ordenaFrequencia();
                switch (opcao)
                {
                    case 1:
                        lp.showList();
                        break;
                    case 2:
                        lp.showListInvertido();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            
        }

        public static void exibe_palavras_nro(ListaDeLetras lettersList)
        {
            Console.WriteLine("\n> Digite o número de ocorrencias: ");
            int num = int.Parse(Console.ReadLine());

            ListaDePalavras? lp = lettersList.pesquisaPorNumeroDeOcorrencia(num);
            if(lp!=null)
            {
                lp.showList();
                return;
            }

            Console.WriteLine("Nenhuma palavra encontrada com o número de ocorrencia digitado.");
        }
    }
}
