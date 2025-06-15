// Trabalho de Engenharia da Computação - Orientação a Objetos
// Implementação de Árvore AVL com operações de inserção, remoção, busca e impressão

using System;
using System.IO;

class NodoAVL
{
    public int Valor;
    public NodoAVL Esquerda;
    public NodoAVL Direita;
    public int Altura;

    public NodoAVL(int valor)
    {
        Valor = valor;
        Altura = 1;
    }
}

class ArvoreAVL
{
    private NodoAVL raiz;

    public void ExecutarComandos(string caminhoArquivo)
    {
        foreach (var linha in File.ReadAllLines(caminhoArquivo))
        {
            var partes = linha.Split();
            if (partes.Length == 0) continue;

            switch (partes[0])
            {
                case "I": Inserir(int.Parse(partes[1])); break;
                case "R": Remover(int.Parse(partes[1])); break;
                case "B": Buscar(int.Parse(partes[1])); break;
                case "P": ImprimirPreOrdem(); break;
                case "F": ImprimirFatores(); break;
                case "H": Console.WriteLine("Altura da árvore: " + Altura(raiz)); break;
            }
        }
    }

    private int Altura(NodoAVL n) => n?.Altura ?? 0;
    private int FatorBalanceamento(NodoAVL n) => n == null ? 0 : Altura(n.Esquerda) - Altura(n.Direita);

    private NodoAVL RotacaoDireita(NodoAVL y)
    {
        var x = y.Esquerda;
        var T2 = x.Direita;
        x.Direita = y;
        y.Esquerda = T2;
        AtualizarAltura(y);
        AtualizarAltura(x);
        return x;
    }

    private NodoAVL RotacaoEsquerda(NodoAVL x)
    {
        var y = x.Direita;
        var T2 = y.Esquerda;
        y.Esquerda = x;
        x.Direita = T2;
        AtualizarAltura(x);
        AtualizarAltura(y);
        return y;
    }

    private void AtualizarAltura(NodoAVL n) => n.Altura = 1 + Math.Max(Altura(n.Esquerda), Altura(n.Direita));

    public void Inserir(int valor)
    {
        raiz = InserirRec(raiz, valor);
    }

    private NodoAVL InserirRec(NodoAVL no, int valor)
    {
        if (no == null) return new NodoAVL(valor);
        if (valor < no.Valor) no.Esquerda = InserirRec(no.Esquerda, valor);
        else if (valor > no.Valor) no.Direita = InserirRec(no.Direita, valor);
        else return no;

        AtualizarAltura(no);
        return Balancear(no);
    }

    public void Remover(int valor)
    {
        raiz = RemoverRec(raiz, valor);
    }

    private NodoAVL RemoverRec(NodoAVL no, int valor)
    {
        if (no == null) return no;
        if (valor < no.Valor) no.Esquerda = RemoverRec(no.Esquerda, valor);
        else if (valor > no.Valor) no.Direita = RemoverRec(no.Direita, valor);
        else
        {
            if (no.Esquerda == null || no.Direita == null)
                no = no.Esquerda ?? no.Direita;
            else
            {
                NodoAVL temp = MinValorNodo(no.Direita);
                no.Valor = temp.Valor;
                no.Direita = RemoverRec(no.Direita, temp.Valor);
            }
        }

        if (no == null) return no;
        AtualizarAltura(no);
        return Balancear(no);
    }

    private NodoAVL MinValorNodo(NodoAVL no)
    {
        NodoAVL atual = no;
        while (atual.Esquerda != null)
            atual = atual.Esquerda;
        return atual;
    }

    public void Buscar(int valor)
    {
        Console.WriteLine(BuscarRec(raiz, valor) != null ? "Valor encontrado" : "Valor não encontrado");
    }

    private NodoAVL BuscarRec(NodoAVL no, int valor)
    {
        if (no == null || no.Valor == valor) return no;
        return valor < no.Valor ? BuscarRec(no.Esquerda, valor) : BuscarRec(no.Direita, valor);
    }

    public void ImprimirPreOrdem()
    {
        Console.Write("Árvore em pré-ordem: ");
        PreOrdem(raiz);
        Console.WriteLine();
    }

    private void PreOrdem(NodoAVL no)
    {
        if (no == null) return;
        Console.Write(no.Valor + " ");
        PreOrdem(no.Esquerda);
        PreOrdem(no.Direita);
    }

    public void ImprimirFatores()
    {
        Console.WriteLine("Fatores de balanceamento:");
        ImprimirFatoresRec(raiz);
    }

    private void ImprimirFatoresRec(NodoAVL no)
    {
        if (no == null) return;
        Console.WriteLine($"Nó {no.Valor}: Fator de balanceamento {FatorBalanceamento(no)}");
        ImprimirFatoresRec(no.Esquerda);
        ImprimirFatoresRec(no.Direita);
    }

    private NodoAVL Balancear(NodoAVL no)
    {
        int fator = FatorBalanceamento(no);
        if (fator > 1)
        {
            if (FatorBalanceamento(no.Esquerda) < 0)
                no.Esquerda = RotacaoEsquerda(no.Esquerda);
            return RotacaoDireita(no);git init
git remote add origin https://github.com/SEU_USUARIO/trabalho-arvore-avl.git

        }
        if (fator < -1)
        {
            if (FatorBalanceamento(no.Direita) > 0)
                no.Direita = RotacaoDireita(no.Direita);
            return RotacaoEsquerda(no);
        }
        return no;
    }
}

class Programa
{
    static void Main(string[] args)
    {
        var arvore = new ArvoreAVL();
        Console.WriteLine("Digite o caminho do arquivo de entrada:");
        string caminho = Console.ReadLine();
        arvore.ExecutarComandos(caminho);
    }
}
