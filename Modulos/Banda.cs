namespace ScreenSound.Modulos;

internal class Banda : IAvaliar
{
    private List<Album> albuns = new List<Album>();
    private List<Avaliacao> notas = new List<Avaliacao>();

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }

    public string? Resumo { get; set; }
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
                if(nota.Nota < 0)
                {
                    return 0;
                }
                if(nota.Nota > 10)
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

    public List<Album> Albuns => albuns;

    public void AdicionarAlbum(Album album) 
    { 
        albuns.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}