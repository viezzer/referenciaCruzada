using System;
using System.IO;

namespace refCruzada
{
    public class ListaDePalavras
    {
        public NodeP? head {get;set;}
        public NodeP? tail {get;set;}
        public int size;
        public int ocorrencias;

        public ListaDePalavras()
        {
            head=null;
            tail=null;
            size=0;
            ocorrencias=0;
        }

        public void addFirst(NodeP newNode)
        {
            //nenhum item na lista
            if(head==null)
            {
                head=newNode;
                tail=newNode;
                size++;
                ocorrencias++;
                return;
            }
            //ja existe pelo menos um item na lista
            //se a palavra ja estiver na lista aumentar a frequencia da mesma
            NodeP? pesquisada = pesquisaPalavra(newNode.palavra);
            if(pesquisada!=null)
            {
                pesquisada.freq++;
            }
            //se a palavra nao estiver na lista adicionar na frente
            else
            {
                newNode.prox = head;
                head.ant=newNode;
                head=newNode;
                size++;
            }
            ocorrencias++;
        }

        
        public void addLast(NodeP newWord)
        {
            //verifica se a palavra ja existe, caso exista aumenta a frequencia no nodo
            ocorrencias++;
            NodeP? pesquisada = pesquisaPalavra(newWord.palavra);
            if(pesquisada!=null)
            {
                pesquisada.freq++;
                return;
            }

            //nenhum item na lista
            if(tail==null)
            {
                head=newWord;
                tail=newWord;
            }
            //ja existem palavras na lista
            else
            {
                tail.prox=newWord;
                newWord.ant = tail;
                tail=newWord;
                size++;
            }
        }

        public void inserePalavra(NodeP nova)
        {
            //nenhuma palavra na lista
            if(head==null)
            {
                addFirst(nova);
                return;
            }
            //palavra ja esta na lista, aumenta frequencia da palavra
            NodeP? pesquisada=pesquisaPalavra(nova.palavra);
            if(pesquisada!=null){
                ocorrencias++;
                pesquisada.freq++;
                return;
            }
            //palavra não esta na lista, inserir ordenada
            NodeP? aux=head;
            NodeP? ant=head.ant;
            while(aux!=null && aux.palavra.CompareTo(nova.palavra)<0)
            {
                ant=aux;
                aux=aux.prox;
            }
            if(ant==null && aux!=null)
            {
                addFirst(nova);

            } 
            else if(ant!=null && aux==null)
            {
                addLast(nova);
            }
            else if(ant!=null && aux!=null)
            {
                ant.prox=nova;
                nova.ant=ant;
                nova.prox=aux;
                aux.ant=nova;
                size++;
                ocorrencias++;
            }

        }

        public NodeP? pesquisaPalavra(string p)
        {
            NodeP? nodo = head;
            while(nodo!=null)
            {
                //verificar se a palavra do nodo é igual a p
                if(nodo.palavra.ToLower()==p.ToLower())
                {
                    return nodo;
                }
                nodo=nodo.prox;
            }
            return null;
        }

        public NodeP? pesquisaPalavraNroOcorrencia(int n)
        {
            NodeP? nodo = head;
            while(nodo!=null)
            {
                //verificar se a palavra do nodo tem o numero de ocorrencias n
                if(nodo.freq==n)
                {
                    return nodo;
                }
                nodo=nodo.prox;
            }
            return null;
        }

        public Boolean remove(string p)
        {
            // remove inicio
            if(head!=null && head.palavra.ToLower()==p.ToLower()){
                ocorrencias -= head.freq;
                if(head.prox==null)
                {
                    head=null;
                    tail=null;
                }
                else
                {
                    head.prox.ant=null;
                    head=head.prox;
                }
                size--;
                return true;
            }
            //remove fim
            else if(tail!=null && tail.palavra.ToLower()==p.ToLower())
            {
                ocorrencias-=tail.freq;
                if (tail.ant == null)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    tail.ant.prox = null;
                    tail = tail.ant;
                }
                size--;
                return true;
            }
            //remove meio
            NodeP? aux=head;
            while(aux!=null)
            {
                if(aux.palavra.ToLower()==p.ToLower()){
                    ocorrencias -= aux.freq;
                    aux.ant.prox = aux.prox;
                    aux.prox.ant = aux.ant;
                    size--;
                    return true;
                }
                aux=aux.prox;
            }
            return false;
        }

        public void showList()
        {
            NodeP? aux=head;

            Console.Write("Palavras: ");
            while(aux!=null)
            {
                if(aux.prox!=null){
                    Console.Write(aux.palavra+" ["+aux.freq+"] - ");
                }
                else
                {
                    Console.Write(aux.palavra+" ["+aux.freq+"]");    
                }
                aux=aux.prox;
            }
        }

        public void showListInvertido()
        {
            NodeP? aux=tail;

            Console.Write("Palavras: ");
            while(aux!=null)
            {
                if(aux.ant==null){
                    Console.Write(aux.palavra+" ["+aux.freq+"]");    
                }
                else{
                    Console.Write(aux.palavra+" ["+aux.freq+"] - ");
                }
                aux=aux.ant;
            }
        }

        public void ordenaFrequencia()
        {
            NodeP? atual = head;
            while (atual != null)
            {
                NodeP? minNode = atual;
                NodeP? aux = atual.prox;

                while (aux != null)
                {
                    if (aux.freq < minNode.freq)
                    {
                        minNode = aux;
                    }
                    aux = aux.prox;
                }

                if (atual != minNode)
                {
                    // Trocar o conteúdo dos nodos
                    string tempPalavra = atual.palavra;
                    int tempFreq = atual.freq;
                    atual.palavra = minNode.palavra;
                    atual.freq = minNode.freq;
                    minNode.palavra = tempPalavra;
                    minNode.freq = tempFreq;
                }

                atual = atual.prox;
            }
        }
    }
}