using ScreenSound.Modulos;

namespace ScreenSound.Menus;
using OpenAI_API;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {

        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda)){
            Console.WriteLine("Está banda já está registrada!");
            Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Banda banda = new Banda(nomeDaBanda);

            bandasRegistradas.Add(nomeDaBanda, banda);

            var client = new OpenAIAPI("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");

            var chat = client.Chat.CreateConversation();

            chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 parágrafo, adote um estilo informal.");
        
            //string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();

            //banda.Resumo = resposta;

            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
            Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        

    }
}
