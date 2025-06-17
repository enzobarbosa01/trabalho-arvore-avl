public class NodoAVL
{
    public int Valor;
    public NodoAVL? Esquerda;
    public NodoAVL? Direita;
    public int Altura;

    public NodoAVL(int valor)
    {
        Valor = valor;
        Altura = 1;
    }
}
