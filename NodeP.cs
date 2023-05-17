public class NodeP
{
    public string palavra {get;set;}
    public int freq {get;set;}
    public NodeP? prox {get;set;}
    public NodeP? ant {get;set;}

    public NodeP(string p){
        palavra=p;
        freq=1;
        prox=null;
        ant=null;
    }
}