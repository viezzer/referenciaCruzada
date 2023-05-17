
namespace refCruzada
{
    public class NodeL
    {
        public char letra { get; set; }
        public ListaDePalavras lista;
        public NodeL? prox { get; set; }
        public NodeL? ant { get; set; }

        public NodeL(char l)
        {
            letra = l;
            lista= new ListaDePalavras();
            prox = null;
            ant = null;
        }
    }
}
