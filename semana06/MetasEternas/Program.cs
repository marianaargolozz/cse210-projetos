// S06 - Projeto: Programa de Metas Eternas
// Autora: Mariana Argollo
//
// CRIATIVIDADE (além dos requisitos básicos):
// Adicionei um sistema de níveis e títulos. A cada 500 pontos, o jogador
// sobe de nível; a tela mostra a evolução e uma mensagem de comemoração.
// Também acrescentei validação das entradas e tratamento de erros ao
// salvar/carregar, sem perder os dados anteriores quando o arquivo é inválido.

public class Program
{
    public static void Main(string[] args)
    {
        GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();
        gerenciador.Iniciar();
    }
}
