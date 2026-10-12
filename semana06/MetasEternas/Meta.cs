using System;
using System.Text;

public abstract class Meta
{
    private readonly string _nome;
    private readonly string _descricao;
    private readonly int _pontos;

    protected Meta(string nome, string descricao, int pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
    }

    public string ObterNome() => _nome;
    protected int ObterPontos() => _pontos;
    protected string ObterDescricaoBase() => _descricao;

    public abstract int RegistrarEvento();
    public abstract bool EstaConcluida();

    public virtual string ObterDetalhesEmTexto()
    {
        string marcador = EstaConcluida() ? "X" : " ";
        return $"[{marcador}] {_nome} ({_descricao})";
    }

    public abstract string ObterRepresentacaoEmTexto();

    // Codifica textos para que os separadores do arquivo não causem problemas.
    protected static string Codificar(string valor) => Convert.ToBase64String(Encoding.UTF8.GetBytes(valor));
    public static string Decodificar(string valor) => Encoding.UTF8.GetString(Convert.FromBase64String(valor));
}
