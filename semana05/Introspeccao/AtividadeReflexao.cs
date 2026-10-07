using System;
using System.Collections.Generic;

public class AtividadeReflexao : Atividade
{
    private List<string> _mensagens;
    private List<string> _perguntas;
    private Random _aleatorio;

    public AtividadeReflexao()
        : base(
            "Atividade de Reflexão",
            "Esta atividade ajudará você a refletir sobre momentos da sua vida em que demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que possui e como pode usá-lo em outros aspectos da sua vida."
        )
    {
        _mensagens = new List<string>()
        {
            "Pense em uma ocasião em que você defendeu outra pessoa.",
            "Pense em uma ocasião em que você fez algo realmente difícil.",
            "Pense em uma ocasião em que você ajudou alguém necessitado.",
            "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
        };

        _perguntas = new List<string>()
        {
            "Por que essa experiência foi significativa para você?",
            "Você já fez algo assim antes?",
            "Como você começou?",
            "Como você se sentiu quando terminou?",
            "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
            "Qual é a sua coisa favorita sobre essa experiência?",
            "O que você pode aprender com essa experiência que se aplica a outras situações?",
            "O que você aprendeu sobre si mesmo por meio dessa experiência?",
            "Como você pode manter essa experiência em mente no futuro?"
        };

        _aleatorio = new Random();
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("\nConsidere a seguinte situação:\n");

        string mensagem = ObterMensagemAleatoria();

        Console.WriteLine($"--- {mensagem} ---");

        Console.WriteLine(
            "\nQuando você tiver algo em mente, pressione Enter para continuar."
        );

        Console.ReadLine();

        Console.WriteLine(
            "\nAgora reflita sobre cada uma das perguntas relacionadas a essa experiência."
        );

        Console.Write("\nVocê pode começar em: ");
        ExibirContagemRegressiva(5);

        Console.Clear();

        DateTime tempoFinal =
            DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            string pergunta = ObterPerguntaAleatoria();

            Console.Write($"> {pergunta} ");

            ExibirSpinner(6);

            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }

    private string ObterMensagemAleatoria()
    {
        int indice = _aleatorio.Next(_mensagens.Count);

        return _mensagens[indice];
    }

    private string ObterPerguntaAleatoria()
    {
        int indice = _aleatorio.Next(_perguntas.Count);

        return _perguntas[indice];
    }
}