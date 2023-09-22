namespace ScreenSound.Modulos;

internal class Avaliacao
{
    public Avaliacao(int nota)
    {
        Nota = nota;
    }

    public int Nota { get; }

    public static Avaliacao Parse(string valor)
    {
        int nota = int.Parse(valor);
        return new Avaliacao(nota);
    }
}
