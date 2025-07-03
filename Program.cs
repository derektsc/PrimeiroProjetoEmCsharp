// Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound!";
// List<string> listaDasBandas = new List<string> {"Banda Teste", "U2" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 10 ,10});
bandasRegistradas.Add("Coldplay", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░░██████╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗██╔════╝
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║╚█████╗░
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║░╚═══██╗
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ShowOptionsMenu()
{
    ExibirLogo(); // Exibe o logo e a mensagem de boas-vindas
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 5 para sair");
    
    Console.Write("\nEscolha uma opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBandas();
            break;
        case 2: MostrarBandas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: MediaDaBanda();
            break;
        case 5: Console.WriteLine("Saindo do programa...");
            break;
        default: Console.WriteLine("Opção inválida, tente novamente.");
            break;

    }

}

void RegistrarBandas()
{
    // Limpar o console
    Console.Clear();
    ExibirTituloDaOpcao("Registro das Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    // listaDasBandas.Add(nomeDaBanda); // Adiciona o nome da banda à lista
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!"); // Usando interpolação, precisa inserir o $ antes da string e usar chaves para a variavel
    Thread.Sleep(1000); // Pausa de 2 segundos para o usuário ler a mensagem
    Console.Clear(); // Limpa o console após registrar a banda
    ShowOptionsMenu(); // Chama novamente o menu de opções após registrar a banda
}

void MostrarBandas() // Utilizando for e foreach
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    // Primeira forma de realizar um for
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}
    // Segunda forma de realizar um for
    foreach (string banda in bandasRegistradas.Keys) // Keys retorna as chaves do dicionário, que são os nomes das bandas
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey(); // Aguarda o usuário pressionar uma tecla antes de voltar ao menu
    Console.Clear(); // Limpa o console após mostrar as bandas
    ShowOptionsMenu(); // Chama novamente o menu de opções após mostrar as bandas
}

void ExibirTituloDaOpcao(string titulo) // Utilizando Lenght e PadLeft
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine($"\n{asteriscos}");
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliando Bandas");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write("Digite a nota de 0 a 10: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota); // Adiciona a nota à lista de notas da banda
        Console.WriteLine($"A nota {nota} foi registrada para a banda {nomeDaBanda} com sucesso!");
        Thread.Sleep(2000); // Pausa de 1 segundo para o usuário ler a mensagem
        Console.Clear(); // Limpa o console após registrar a nota
        ShowOptionsMenu(); // Chama novamente o menu de opções após avaliar a banda
    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        ShowOptionsMenu();
    }

}

void MediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média das Bandas");
    Console.Write("Digite o nome da banda que deseja calcular a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notas = bandasRegistradas[nomeDaBanda];
        if (notas.Count > 0)
        {
            double media = notas.Average(); // Calcula a média das notas
            Console.WriteLine($"A média das notas da banda {nomeDaBanda} é: {media}");
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não possui avaliações registradas.");
        }
    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada.");
    }
}

ExibirLogo();
ShowOptionsMenu();