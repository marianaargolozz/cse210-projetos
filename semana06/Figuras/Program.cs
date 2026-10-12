using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Figura> figuras = new List<Figura>();

        Quadrado quadrado = new Quadrado("Vermelho", 5);
        Retangulo retangulo = new Retangulo("Azul", 4, 6);
        Circulo circulo = new Circulo("Verde", 3);

        figuras.Add(quadrado);
        figuras.Add(retangulo);
        figuras.Add(circulo);

        foreach (Figura figura in figuras)
        {
            Console.WriteLine($"Cor: {figura.ObterCor()}");
            Console.WriteLine($"Área: {figura.ObterArea():F2}");
            Console.WriteLine("--------------------");
        }
    }
}
