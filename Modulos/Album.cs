namespace ScreenSound.Modulos;

internal class Album
{
    private List<Musica> musicas = new List<Musica>();
    private List<Avaliacao> notas = new();

    public Album(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    public List<Musica> Musicas => musicas;

    public double Media
    {
        get
        {
            if (notas.Count == 0)
            {
                return 0; // Retorna 0 se não houver notas
            }

            double somaNotas = 0;

            foreach (var nota in notas)
            {
                if (nota.Nota < 0)
                {
                    return 0;
                }
                if (nota.Nota > 10)
                {
                    return 10;
                }
                if (nota.Nota >= 0 && nota.Nota <= 10)
                {
                    somaNotas += nota.Nota; // Adiciona a nota válida à soma
                }
            }

            return somaNotas / notas.Count; // Retorna a média das notas válidas
        }
    }

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);    
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal}");
    }
}