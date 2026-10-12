public class MetaDeListaDeTarefas : Meta
{
    private int _concluidas;
    private readonly int _total;
    private readonly int _bonus;

    public MetaDeListaDeTarefas(string nome, string descricao, int pontos, int total, int bonus, int concluidas = 0)
        : base(nome, descricao, pontos)
    {
        _total = total;
        _bonus = bonus;
        _concluidas = concluidas;
    }

    public override int RegistrarEvento()
    {
        if (EstaConcluida()) return 0;
        _concluidas++;
        return ObterPontos() + (EstaConcluida() ? _bonus : 0);
    }

    public override bool EstaConcluida() => _concluidas >= _total;

    public override string ObterDetalhesEmTexto() =>
        $"{base.ObterDetalhesEmTexto()} -- Concluída {_concluidas}/{_total} vezes";

    public override string ObterRepresentacaoEmTexto() =>
        $"Lista|{Codificar(ObterNome())}|{Codificar(ObterDescricaoBase())}|{ObterPontos()}|{_total}|{_bonus}|{_concluidas}";
}
