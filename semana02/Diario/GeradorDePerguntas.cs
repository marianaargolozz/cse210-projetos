public class GeradorDePerguntas
{
    public List<string> _perguntas = new List<string>()
    {
        "Qual foi a melhor parte do meu dia?",
        "O que me deixou feliz hoje?",
        "Por qual coisa sou grato hoje?",
        "Qual foi a emoção mais forte que senti hoje?",
        "O que eu poderia fazer melhor amanhã?"
    };

    public string ObterPerguntaAleatoria()
    {
        Random random = new Random();
        int numero = random.Next(_perguntas.Count);

        return _perguntas[numero];
    }
}