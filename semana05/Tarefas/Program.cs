using System;

class Program
{
    static void Main(string[] args)
    {
        TarefaDeMatematica matematica = new TarefaDeMatematica(
            "Mariana Argolo",
            "Frações",
            "7.3",
            "8-19"
        );

        Console.WriteLine(matematica.ObterResumo());
        Console.WriteLine(matematica.ObterListaDeTarefas());

        Console.WriteLine();

        TarefaDeRedacao redacao = new TarefaDeRedacao(
            "Mariana Argolo",
            "História da Europa",
            "As Causas da Segunda Guerra Mundial"
        );

        Console.WriteLine(redacao.ObterResumo());
        Console.WriteLine(redacao.ObterInformacoesDaRedacao());
    }
}