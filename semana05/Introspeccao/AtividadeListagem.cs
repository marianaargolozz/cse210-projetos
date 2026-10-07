using System;
using System.Collections.Generic;

public class AtividadeListagem : Atividade
{
    private List<string> _mensagens;
    private Random _aleatorio;

    public AtividadeListagem()
        : base(
            "Atividade de Listagem",
            "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área."
        )
    {
        _mensagens = new List<string>()
        {
            "Quem são as pessoas que você aprecia?",
            "Quais são seus pontos fortes pessoais?",
            "Quem são as pessoas que você ajudou esta semana?",
            "Quando você sentiu o Espírito Santo neste mês?",
            "Quem são alguns dos seus heróis pessoais?"
        };

        _aleatorio = new Random();
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine(
            "\nListe o máximo de respostas que puder para a seguinte pergunta:"
        );

        string mensagem = ObterMensagemAleatoria();

        Console.WriteLine($"\n--- {mensagem} ---");

        Console.Write("\nVocê pode começar em: ");
        ExibirContagemRegressiva(5);

        Console.WriteLine();

        int quantidade = 0;

        DateTime tempoFinal =
            DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            Console.Write("> ");

            Console.ReadLine();

            quantidade++;
        }

        Console.WriteLine(
            $"\nVocê listou {quantidade} itens!"
        );

        ExibirMensagemFinal();
    }

    private string ObterMensagemAleatoria()
    {
        int indice = _aleatorio.Next(_mensagens.Count);

        return _mensagens[indice];
    }
}