public class MetaSimples : Meta
{
    private bool _estaConcluida;

    public MetaSimples(string nome, string descricao, int pontos, bool estaConcluida = false)
        : base(nome, descricao, pontos)
    {
        _estaConcluida = estaConcluida;
    }

    public override int RegistrarEvento()
    {
        if (_estaConcluida) return 0;
        _estaConcluida = true;
        return ObterPontos();
    }

    public override bool EstaConcluida() => _estaConcluida;

    public override string ObterRepresentacaoEmTexto() =>
        $"Simples|{Codificar(ObterNome())}|{Codificar(ObterDescricaoBase())}|{ObterPontos()}|{_estaConcluida}";

}
