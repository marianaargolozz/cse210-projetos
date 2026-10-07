using System;
using System.Collections.Generic;
using System.Threading;

public class Atividade
{
    private string _nome;
    private string _descricao;
    private int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
        _duracao = 0;
    }

    public int ObterDuracao()
    {
        return _duracao;
    }

    public void ExibirMensagemInicial()
    {
        Console.Clear();

        Console.WriteLine($"Bem-vindo(a) à {_nome}.\n");
        Console.WriteLine(_descricao);

        Console.Write("\nQuanto tempo, em segundos, você gostaria que sua sessão durasse? ");

        string entrada = Console.ReadLine();

        while (!int.TryParse(entrada, out _duracao) || _duracao <= 0)
        {
            Console.Write("Digite um número válido maior que zero: ");
            entrada = Console.ReadLine();
        }

        Console.Clear();

        Console.WriteLine("Prepare-se...");
        ExibirSpinner(3);

        Console.WriteLine();
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine("\nMuito bem!");
        ExibirSpinner(2);

        Console.WriteLine(
            $"\nVocê concluiu {_duracao} segundos da {_nome}."
        );

        ExibirSpinner(3);

        Console.WriteLine();
    }

    public void ExibirSpinner(int segundos)
    {
        List<string> animacao = new List<string>()
        {
            "|", "/", "-", "\\"
        };

        DateTime tempoFinal = DateTime.Now.AddSeconds(segundos);

        int indice = 0;

        while (DateTime.Now < tempoFinal)
        {
            Console.Write(animacao[indice]);

            Thread.Sleep(250);

            Console.Write("\b \b");

            indice++;

            if (indice >= animacao.Count)
            {
                indice = 0;
            }
        }
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);

            Thread.Sleep(1000);

            Console.Write("\b \b");
        }
    }
}