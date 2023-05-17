using System;

namespace refCruzada
{
    public class ListaDeLetras
    {
        public NodeL? head {get;set;}
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

        public void insereLetra(char l)
        {
            NodeL novoNodo = new NodeL(l);
            // nenhuma letra na lista
            if(head==null)
            {
                head=novoNodo;
            }
            else
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

        public void inserePalavra(char l, string p){
            NodeL? nodo = pesquisaLetra(l);
            nodo.lista.inserePalavra(p);
        }

        public NodeL? pesquisaLetra(char l){
            NodeL? aux = head;
            while(aux!=null){
                if(aux.letra==l){
                    return aux;
                }
                aux=aux.prox;
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
            
        }
    }
}