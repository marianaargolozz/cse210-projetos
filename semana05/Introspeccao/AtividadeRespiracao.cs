using System;

public class AtividadeRespiracao : Atividade
{
    public AtividadeRespiracao()
        : base(
            "Atividade de Respiração",
            "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração."
        )
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine();

        DateTime tempoFinal =
            DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < tempoFinal)
        {
            Console.Write("\nInspire... ");
            ExibirContagemRegressiva(4);

            if (DateTime.Now >= tempoFinal)
            {
                break;
            }

            Console.Write("\nExpire... ");
            ExibirContagemRegressiva(6);

            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }
}