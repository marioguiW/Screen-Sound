

using ScreenSound.Menus;
using ScreenSound.Modulos;

Dictionary<string, Banda> bandasRegistradas = new();

Banda ira = new Banda("Ira!");
Banda beatles = new Banda("The Beatles");

bandasRegistradas.Add(ira.Nome, ira);
bandasRegistradas.Add(beatles.Nome, beatles);

ira.AdicionarNota(new Avaliacao(10));
ira.AdicionarNota(new Avaliacao(8));

beatles.AdicionarNota(new Avaliacao(9));
beatles.AdicionarNota(new Avaliacao(7));
void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um album");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    Dictionary<int, Menu> opcao = new();

    opcao.Add(1, new MenuRegistrarBanda());
    opcao.Add(2, new MenuRegistrarAlbum());
    opcao.Add(3, new MenuMostrarBandasRegistradas());
    opcao.Add(4, new MenuAvaliarBanda());
    opcao.Add(5, new MenuAvaliarAlbum());
    opcao.Add(6, new MenuExibirDetalhes());
    opcao.Add(-1, new MenuSair());

    if (opcao.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menu = opcao[opcaoEscolhidaNumerica];
        menu.Executar(bandasRegistradas);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Invalido!");
    }

}
ExibirOpcoesDoMenu();

