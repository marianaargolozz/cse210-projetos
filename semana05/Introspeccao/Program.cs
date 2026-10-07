using System;
using System.Threading;

/*
REQUISITO EXCEDIDO:

Para superar os requisitos básicos, o programa registra quantas
atividades de introspecção foram concluídas durante a execução.

Quando o usuário encerra o programa, o número total de atividades
concluídas é exibido na tela.
*/

class Program
{
    static void Main(string[] args)
    {
        string escolha = "";
        int atividadesConcluidas = 0;

        while (escolha != "4")
        {
            Console.Clear();

            Console.WriteLine("Opções do Menu:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            Console.WriteLine("  4. Sair");

            Console.Write("\nEscolha uma opção do menu: ");

            escolha = Console.ReadLine();

            if (escolha == "1")
            {
                AtividadeRespiracao atividade =
                    new AtividadeRespiracao();

                atividade.Executar();

                atividadesConcluidas++;

                PausarAntesDoMenu();
            }
            else if (escolha == "2")
            {
                AtividadeReflexao atividade =
                    new AtividadeReflexao();

                atividade.Executar();

                atividadesConcluidas++;

                PausarAntesDoMenu();
            }
            else if (escolha == "3")
            {
                AtividadeListagem atividade =
                    new AtividadeListagem();

                atividade.Executar();

                atividadesConcluidas++;

                PausarAntesDoMenu();
            }
            else if (escolha == "4")
            {
                Console.Clear();

                Console.WriteLine(
                    $"Você concluiu {atividadesConcluidas} atividades de introspecção nesta sessão."
                );

                Console.WriteLine(
                    "\nObrigado por utilizar o programa!"
                );
            }
            else
            {
                Console.WriteLine("\nOpção inválida.");
                Thread.Sleep(1500);
            }
        }
    }

    static void PausarAntesDoMenu()
    {
        Console.WriteLine(
            "\nPressione Enter para voltar ao menu."
        );

        Console.ReadLine();
    }
}