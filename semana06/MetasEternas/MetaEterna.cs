public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos) { }

    public override int RegistrarEvento() => ObterPontos();

    public override bool EstaConcluida() => false;

    public override string ObterRepresentacaoEmTexto() =>
        $"Eterna|{Codificar(ObterNome())}|{Codificar(ObterDescricaoBase())}|{ObterPontos()}";
}
