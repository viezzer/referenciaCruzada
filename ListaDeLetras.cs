using System;

namespace refCruzada
{
    public class ListaDeLetras
    {
        public NodeL? head {get;set;}
        public NodeL? tail {get;set;}
        public int size;
        public ListaDeLetras(string[] words)
        {
            head=null;
            size=0;
            
            foreach (var word in words)
            {
                char l = char.ToLower(word[0]);
                if(head==null){
                    //lista não possui nodo da letra, adicionar nodo 
                    insereLetra(l);
                } else {
                    //verificar se a lista possui nodo com a letra da palavra
                    NodeL? aux= head;
                    while(aux!=null && aux.letra!=l)
                    {
                        aux=aux.prox;
                    }
                    if(aux==null){
                        insereLetra(l);
                    }
                }
                //adicionar palavra
                inserePalavra(l, word);
            }
        }

        public ListaDePalavras? getPalavras()
        {
            if(head==null)
            {
                Console.WriteLine("Lista não possui conteudo");
                return null;
            }
            ListaDePalavras lp = new ListaDePalavras();
            NodeL? aux=head;
            while(aux!=null)
            {
                Console.WriteLine("\nLetra: "+char.ToUpper(aux.letra));
                NodeP? auxPalavra = aux.lista.head;
                while(auxPalavra!=null)
                {
                    Console.WriteLine("Palavra: "+auxPalavra.palavra);
                    lp.addLast(auxPalavra);
                    auxPalavra=auxPalavra.prox;
                }
                aux=aux.prox;
            }
            if(lp.size>0)
            {
                return lp;
            }
            return null;
        }

        public void insereLetra(char l)
        {
            NodeL novoNodo = new NodeL(l);
            // nenhuma letra na lista
            if(head==null)
            {
                head=novoNodo;
                tail=novoNodo;
            }
            else
            //lista ja possui letras
            {
                NodeL? atual=head;
                NodeL? anterior=head.ant;
               
                while(atual!=null && atual.letra<l){
                    anterior=atual;
                    atual=atual.prox;
                }
                //inserir no inicio
                if(anterior==null && atual!=null)
                {
                    atual.ant=novoNodo;
                    novoNodo.prox=atual;
                    head=novoNodo;
                }
                //inserir no final
                else if(atual==null && anterior!=null)
                {
                    novoNodo.ant=anterior;
                    anterior.prox=novoNodo;
                    tail=novoNodo;
                }
                //inserir ordenada
                else if(anterior!=null && atual!=null)
                {
                    novoNodo.ant=anterior;
                    novoNodo.prox=atual;
                    anterior.prox=novoNodo;
                    atual.ant=novoNodo;
                }
            }
            size++;
        }

        public Boolean removeLetra(char l)
        {
            //remove inicio
            if(head!=null && head.letra==l)
            {
                head=head.prox;
                size--;
                return true;
            }
            //remove fim
            if(tail!=null && tail.letra==l)
            {
                tail=tail.ant;
                tail.prox=null;
                size--;
                return true;
            }
            //remove meio
            NodeL? aux=head, ant=head.ant;
            while(aux!=null)
            {
                if(aux.letra==l)
                {
                    ant.prox=aux.prox;
                    size--;
                    return true;
                }
                ant=aux;
                aux=aux.prox;
            }
            return false;
        }

        public void inserePalavra(char l, string p)
        {
            NodeL? nodo = pesquisaLetra(l);
            NodeP nodoP = new NodeP(p);
            nodo.lista.inserePalavra(nodoP);
        }

        public int contaPalavras()
        {
            int conta = 0;
            NodeL aux = head;
            while(aux!=null)
            {
                conta+=aux.lista.size;
                aux=aux.prox;
            }
            return conta;
        }

        public int contaOcorrencias()
        {
            int conta = 0;
            NodeL aux = head;
            while(aux!=null)
            {
                conta+=aux.lista.ocorrencias;
                aux=aux.prox;
            }
            return conta;
        }

        public ListaDePalavras filtraLetra(char l)
        {
            NodeL? nodoL = pesquisaLetra(l);
            ListaDePalavras lp;
            if(nodoL!=null)
            {
                lp = nodoL.lista;
                //se a lista tiver palavras retornar lista
                if(lp.size>0)
                {
                    return lp;
                }
            }
            return null;
        }

        public NodeL? pesquisaLetra(char l)
        {
            NodeL? aux = head;
            while(aux!=null){
                if(aux.letra==l){
                    return aux;
                }
                aux=aux.prox;
            }
            return null;
        }

        public Boolean removePalavra(string p)
        {
            NodeL? nodoL = pesquisaLetra(p[0]);

            if(nodoL!=null)
            {
                if(nodoL.lista.remove(p))
                {
                    if(nodoL.lista.size==0){
                        Console.WriteLine("removendo Letra...");

                        if(removeLetra(nodoL.letra))
                        {
                            Console.WriteLine("letra removida");
                        }
                    }
                    return true;
                }  

            }
            return false;
        }

        public ListaDePalavras? pesquisaPorNumeroDeOcorrencia(int n)
        {
            // criar nova lista de palavras
            ListaDePalavras lp = new ListaDePalavras();
            //adicionar palavras que possuem o numero de ocorrencias na lista
            NodeL? aux=head;
            //percorre lista das letras
            while(aux!=null)
            {
                //itera sobre as palavras da lista da letra 
                NodeP? auxP = aux.lista.head;
                while(auxP!=null){
                    if(auxP.freq==n)
                    {
                        lp.inserePalavra(auxP);
                    }
                    auxP = auxP.prox;
                }
                aux=aux.prox;
            }

            if(lp.size>0)
            {
                return lp;
            }
            return null;
        }

        public void exibir()
        {
            if(head==null)
            {
                Console.WriteLine("Lista não possui conteudo");
                return;
            }
            NodeL? aux=head;
            while(aux!=null)
            {
                Console.WriteLine("\nLetra: "+char.ToUpper(aux.letra));
                aux.lista.showList();
                aux=aux.prox;
            }
        }

        public void exibirInvertido(){
            if(tail==null)
            {
                Console.WriteLine("Lista não possui conteudo");
                return;
            }
            NodeL? aux=tail;
            while(aux!=null)
            {
                Console.WriteLine("\nLetra: "+char.ToUpper(aux.letra));
                aux.lista.showListInvertido();
                aux=aux.ant;
            }
        }
    }
}