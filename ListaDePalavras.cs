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

        public void inserePalavra(string p)
        {
            NodeP nova = new NodeP(p);
            //nenhuma palavra na lista
            if(head==null)
            {
                addFirst(nova);
                return;
            }
            //palavra ja esta na lista, aumenta frequencia da palavra
            NodeP? pesquisada=pesquisaPalavra(p);
            if(pesquisada!=null){
                ocorrencias++;
                pesquisada.freq++;
                return;
            }
            //palavra não esta na lista, inserir ordenada
            NodeP? aux=head;
            NodeP? ant=head.ant;
            while(aux!=null && aux.palavra.CompareTo(p)<0)
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
                if(nodo.palavra.ToLower()==p)
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
            NodeP? aux=head, ant=head;
            if(head!=null && head.palavra==p){
                ocorrencias -= head.freq;
                head=head.prox;
                size--;
                return true;
            }
            else if(tail!=null && tail.palavra==p)
            {
                ocorrencias-=tail.freq;
                tail=tail.ant;
                size--;
                return true;
            }

            while(aux!=null)
            {
                if(aux.palavra==p){
                    ocorrencias-=aux.freq;
                    ant.prox=aux.prox;
                    size--;
                    return true;
                }
                ant=aux;
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
                if(aux.prox==null){
                    Console.Write(aux.palavra+" ["+aux.freq+"]");    
                }
                else{
                    Console.Write(aux.palavra+" ["+aux.freq+"] - ");
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
    }
}