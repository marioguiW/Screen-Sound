namespace ScreenSound.Modulos;

internal interface IAvaliar
{
    void AdicionarNota(Avaliacao nota);

    double Media { get; }

}
