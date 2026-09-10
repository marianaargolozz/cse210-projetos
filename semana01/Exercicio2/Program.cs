using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite sua nota: ");
        int nota = int.Parse(Console.ReadLine());

        string letra = "";

        if (nota >= 90)
        {
            letra = "A";
        }
        else if (nota >= 80)
        {
            letra = "B";
        }
        else if (nota >= 70)
        {
            letra = "C";
        }
        else if (nota >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        Console.WriteLine($"Sua nota é {letra}");

        if (nota >= 70)
        {
            Console.WriteLine("Parabéns, você passou!");
        }
        else
        {
            Console.WriteLine("Você pode tentar novamente na próxima vez.");
        }
    }
}