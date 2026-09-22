using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Para ir além dos requisitos básicos, criei uma pequena biblioteca
        // de escrituras. O programa escolhe uma escritura aleatoriamente.
        // Também fiz o programa esconder somente palavras que ainda estão visíveis.

        List<Scripture> scriptures = new List<Scripture>();

        Reference reference1 = new Reference("Filipenses", 4, 13);
        Scripture scripture1 = new Scripture(
            reference1,
            "Tudo posso naquele que me fortalece."
        );

        Reference reference2 = new Reference("Salmos", 23, 1);
        Scripture scripture2 = new Scripture(
            reference2,
            "O Senhor é o meu pastor; nada me faltará."
        );

        Reference reference3 = new Reference("1 Tessalonicenses", 5, 17);
        Scripture scripture3 = new Scripture(
            reference3,
            "Orai sem cessar."
        );

        scriptures.Add(scripture1);
        scriptures.Add(scripture2);
        scriptures.Add(scripture3);

        Random random = new Random();

        int scriptureIndex = random.Next(scriptures.Count);
        Scripture scripture = scriptures[scriptureIndex];

        string answer = "";

        while (answer.ToLower() != "sair")
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Pressione Enter para continuar ou digite 'sair' para encerrar:");

            answer = Console.ReadLine() ?? "";

            if (answer.ToLower() == "sair")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}