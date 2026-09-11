Diario diario = new Diario();
GeradorDePerguntas gerador = new GeradorDePerguntas();

string opcao = "";

while (opcao != "5")
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. Escrever");
    Console.WriteLine("2. Exibir");
    Console.WriteLine("3. Salvar");
    Console.WriteLine("4. Carregar");
    Console.WriteLine("5. Sair");
    Console.Write("Escolha uma opção: ");

    opcao = Console.ReadLine() ?? "";

    if (opcao == "1")
    {
        string pergunta = gerador.ObterPerguntaAleatoria();

        Console.WriteLine(pergunta);
        string resposta = Console.ReadLine() ?? "";

        Registro registro = new Registro();

        registro._data = DateTime.Now.ToShortDateString();
        registro._textoPergunta = pergunta;
        registro._textoResposta = resposta;

        diario.AdicionarRegistro(registro);
    }

    else if (opcao == "2")
    {
        diario.ExibirTodos();
    }

    else if (opcao == "3")
    {
        Console.Write("Nome do arquivo: ");
        string arquivo = Console.ReadLine() ?? "";

        diario.SalvarNoArquivo(arquivo);
    }

    else if (opcao == "4")
    {
        Console.Write("Nome do arquivo: ");
        string arquivo = Console.ReadLine() ?? "";

        diario.CarregarDoArquivo(arquivo);
    }
}