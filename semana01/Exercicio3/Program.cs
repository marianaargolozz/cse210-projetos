using System;
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int numeroMagico = random.Next(1, 101);

        int palpite = 0;

        while (palpite != numeroMagico)
        {
            Console.Write("Qual é o seu palpite? ");
            palpite = int.Parse(Console.ReadLine());

            if (palpite < numeroMagico)
            {
                Console.WriteLine("Mais alto");
            }
            else if (palpite > numeroMagico)
            {
                Console.WriteLine("Mais baixo");
            }
            else
            {
                Console.WriteLine("Você adivinhou!");
            }
        }
    }
}