using System;

public class Programa
{
    public static void Main(string[] args)
    {
        var arvore = new ArvoreAVL();
        Console.WriteLine("Digite o caminho do arquivo de entrada:");
        string? caminho = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(caminho))
            arvore.ExecutarComandos(caminho);
    }
}
