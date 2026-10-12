using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class GerenciadorDeMetas
{
    private readonly List<Meta> _metas = new List<Meta>();
    private int _pontos = 0;

    public void Iniciar()
    {
        bool executando = true;
        while (executando)
        {
            ExibirInfoJogador();
            Console.WriteLine("\nMenu de opções:");
            Console.WriteLine("1. Criar nova meta");
            Console.WriteLine("2. Listar metas");
            Console.WriteLine("3. Salvar metas");
            Console.WriteLine("4. Carregar metas");
            Console.WriteLine("5. Registrar evento");
            Console.WriteLine("6. Sair");
            int opcao = LerInteiro("Escolha uma opção: ", 1);
            switch (opcao)
            {
                case 1: CriarMeta(); break;
                case 2: ListarDetalhesDasMetas(); break;
                case 3: SalvarMetas(); break;
                case 4: CarregarMetas(); break;
                case 5: RegistrarEvento(); break;
                case 6: executando = false; break;
                default: Console.WriteLine("Opção inválida."); break;
            }
        }
        Console.WriteLine("Até a próxima! Continue avançando em suas metas.");
    }

    public void ExibirInfoJogador()
    {
        // CRIATIVIDADE: sistema extra de níveis e títulos, calculados pelos pontos.
        // Cada 500 pontos representam um novo nível, sem limite máximo.
        int nivel = (_pontos / 500) + 1;
        int progresso = _pontos % 500;
        string titulo = nivel >= 5 ? "Guardião das Metas" :
                        nivel >= 3 ? "Explorador de Conquistas" : "Aprendiz de Metas";
        Console.WriteLine($"\n=== MISSÃO ETERNA ===");
        Console.WriteLine($"Pontos: {_pontos} | Nível: {nivel} ({titulo})");
        Console.WriteLine($"Progresso do nível: {progresso}/500 pontos");
    }

    public void ListarNomesDasMetas()
    {
        for (int i = 0; i < _metas.Count; i++)
            Console.WriteLine($"{i + 1}. {_metas[i].ObterNome()}");
    }

    public void ListarDetalhesDasMetas()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }
        Console.WriteLine("\nSuas metas:");
        for (int i = 0; i < _metas.Count; i++)
            Console.WriteLine($"{i + 1}. {_metas[i].ObterDetalhesEmTexto()}");
    }

    public void CriarMeta()
    {
        Console.WriteLine("\nTipos de metas:");
        Console.WriteLine("1. Meta simples");
        Console.WriteLine("2. Meta eterna");
        Console.WriteLine("3. Meta de lista de tarefas");
        int tipo = LerInteiro("Escolha o tipo: ", 1);
        if (tipo < 1 || tipo > 3) { Console.WriteLine("Tipo inválido."); return; }

        string nome = LerTexto("Nome da meta: ");
        string descricao = LerTexto("Descrição: ");
        int pontos = LerInteiro("Pontos por realização: ", 0);

        Meta meta;
        if (tipo == 1) meta = new MetaSimples(nome, descricao, pontos);
        else if (tipo == 2) meta = new MetaEterna(nome, descricao, pontos);
        else
        {
            int total = LerInteiro("Quantas vezes para concluir? ", 1);
            int bonus = LerInteiro("Bônus ao concluir: ", 0);
            meta = new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus);
        }
        _metas.Add(meta);
        Console.WriteLine("Meta criada com sucesso!");
    }

    public void RegistrarEvento()
    {
        if (_metas.Count == 0) { Console.WriteLine("Cadastre uma meta primeiro."); return; }
        Console.WriteLine("\nQual meta você realizou?");
        ListarNomesDasMetas();
        int indice = LerInteiro("Número da meta: ", 1) - 1;
        if (indice < 0 || indice >= _metas.Count) { Console.WriteLine("Meta inválida."); return; }

        int nivelAnterior = _pontos / 500 + 1;
        int ganhos = _metas[indice].RegistrarEvento(); // Polimorfismo em ação.
        _pontos += ganhos;
        if (ganhos == 0) Console.WriteLine("Esta meta já foi concluída; nenhum ponto adicional.");
        else Console.WriteLine($"Parabéns! Você ganhou {ganhos} pontos.");
        int novoNivel = _pontos / 500 + 1;
        if (novoNivel > nivelAnterior)
            Console.WriteLine($"🏆 Você subiu para o nível {novoNivel}!");
    }

    public void SalvarMetas()
    {
        string arquivo = LerTexto("Nome do arquivo (ex.: metas.txt): ");
        try
        {
            using StreamWriter saida = new StreamWriter(arquivo, false, Encoding.UTF8);
            saida.WriteLine(_pontos);
            foreach (Meta meta in _metas)
                saida.WriteLine(meta.ObterRepresentacaoEmTexto());
            Console.WriteLine("Metas salvas com sucesso!");
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException)
        {
            Console.WriteLine($"Não foi possível salvar: {ex.Message}");
        }
    }

    public void CarregarMetas()
    {
        string arquivo = LerTexto("Nome do arquivo (ex.: metas.txt): ");
        try
        {
            string[] linhas = File.ReadAllLines(arquivo);
            if (linhas.Length == 0) throw new FormatException("Arquivo vazio.");
            int pontosCarregados = int.Parse(linhas[0]);
            if (pontosCarregados < 0) throw new FormatException("Pontuação inválida.");
            List<Meta> metasCarregadas = new List<Meta>();
            for (int i = 1; i < linhas.Length; i++)
            {
                string[] partes = linhas[i].Split('|');
                if (partes.Length < 4) throw new FormatException("Linha de meta incompleta.");
                string nome = Meta.Decodificar(partes[1]);
                string descricao = Meta.Decodificar(partes[2]);
                int pontos = int.Parse(partes[3]);
                if (pontos < 0) throw new FormatException("Pontos de meta inválidos.");
                Meta meta = partes[0] switch
                {
                    "Simples" when partes.Length == 5 =>
                        new MetaSimples(nome, descricao, pontos, bool.Parse(partes[4])),
                    "Eterna" when partes.Length == 4 =>
                        new MetaEterna(nome, descricao, pontos),
                    "Lista" when partes.Length == 7 =>
                        CriarListaSalva(nome, descricao, pontos, partes),
                    _ => throw new FormatException("Tipo de meta desconhecido ou inválido.")
                };
                metasCarregadas.Add(meta);
            }
            // Só altera o jogo depois de validar o arquivo inteiro.
            _metas.Clear();
            _metas.AddRange(metasCarregadas);
            _pontos = pontosCarregados;
            Console.WriteLine("Metas carregadas com sucesso!");
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException ||
                                    ex is ArgumentException || ex is FormatException || ex is OverflowException)
        {
            Console.WriteLine($"Não foi possível carregar: {ex.Message}");
        }
    }

    private static MetaDeListaDeTarefas CriarListaSalva(string nome, string descricao, int pontos, string[] partes)
    {
        int total = int.Parse(partes[4]);
        int bonus = int.Parse(partes[5]);
        int concluidas = int.Parse(partes[6]);
        if (total < 1 || bonus < 0 || concluidas < 0 || concluidas > total)
            throw new FormatException("Progresso da lista inválido.");
        return new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus, concluidas);
    }

    private static string LerTexto(string pergunta)
    {
        while (true)
        {
            Console.Write(pergunta);
            string texto = Console.ReadLine()?.Trim() ?? "";
            if (texto.Length > 0) return texto;
            Console.WriteLine("Digite um texto válido.");
        }
    }

    private static int LerInteiro(string pergunta, int minimo)
    {
        while (true)
        {
            Console.Write(pergunta);
            if (int.TryParse(Console.ReadLine(), out int numero) && numero >= minimo)
                return numero;
            Console.WriteLine($"Digite um número inteiro maior ou igual a {minimo}.");
        }
    }
}
