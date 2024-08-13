using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Alimento
{
    public string Nome { get; }
    public int TempoDeAquecimento { get; }
    public int Potencia { get; }
    public string CaracterAquecimento { get; }

    public Alimento(string nome = null, int tempoDeAquecimento = 0, int potencia = 0, string caracterAquecimento = null)
    {
        Nome = nome;
        Potencia = potencia;
        TempoDeAquecimento = tempoDeAquecimento;
        CaracterAquecimento = caracterAquecimento;
    }

    private static List<Alimento> alimentos = new List<Alimento>
    {
        new Alimento("Frango", 50, 5, "&"),
        new Alimento("Bacon", 120, 3, "x"),
        new Alimento("Bife", 60, 2, "*"),
        new Alimento("Pizza", 2, 1, "#"),
        new Alimento("Lasanha", 90, 4, "!"),
    };

    public void ListarAlimentos()
    {
        ExibirAlimentos(alimentos);
    }

    private static void BuscarAlimento(List<Alimento> lista, string nomeDesejado)
    {
        foreach (Alimento alimento in lista)
        {
            if (alimento.Nome.Equals(nomeDesejado, StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine($"\n O alimento escolhido foi: {nomeDesejado}\n Nivel de aquecimento programado: {alimento.Potencia} \n Tempo definido: {TimeSpan.FromSeconds(alimento.TempoDeAquecimento):mm\\:ss}");
                Console.WriteLine("\n");
                Console.WriteLine("Caso deseje preparar o alimento escolhido tecle 1: ");
                Console.WriteLine("Caso deseje consultar as opções novamente tecle 2: ");
                Console.WriteLine("caso deseje voltar para o modo manual tecle 3");
                Console.Write("\nInforme a opção escolhida: ");

                int opcao = ObterOpcaoValida(1, 3);

                switch (opcao)
                {
                    case 1:
                        try
                        {
                            Microondas microondas = new Microondas();
                            microondas.Aquecer(TimeSpan.FromSeconds(alimento.TempoDeAquecimento), alimento.Potencia, alimento.CaracterAquecimento);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ocorreu um erro durante o aquecimento: " + ex.Message);
                           
                        }
                        break;

                    case 2:
                        Console.Clear();
                        ExibirAlimentos(lista);
                        break;
                    case 3:
                        Console.Clear();
                        new Interface().ExibirOpcoesDeAlimetosDisponiveis();
                        break;
                }
                break; 
            }
        }
    }

    private static void AdicionarNovoAlimento(List<Alimento> alimentos)
    {
        Console.WriteLine("\nDigite as informações do novo alimento:");

        string nome;
        do
        {
            Console.Write("Nome do alimento: ");
            nome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome do alimento não pode ser nulo ou vazio. Por favor, tente novamente.");
            }
            else if (alimentos.Exists(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"O alimento '{nome}' já existe na lista. Por favor, informe um nome diferente.");
                nome = null;
            }

        } while (string.IsNullOrWhiteSpace(nome));

        int tempoAquecimento = ObterValorInteiroValido("Tempo de aquecimento (em segundos, entre 1 e 120): ", 1, 120);

        int potencia = 10; 
        do
        {
            Console.Write("Nível da potência (opcional, 1-10, pressione Enter para usar o padrão 10): ");
            string potenciaStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(potenciaStr))
            {
                break;
            }
            else if (!int.TryParse(potenciaStr, out potencia) || potencia < 1 || potencia > 10)
            {
                Console.WriteLine("Nível inválido. Por favor, insira um valor inteiro entre 1 e 10 ou pressione Enter para usar o padrão.");
            }
            else
            {
                break;
            }
        } while (true);

        Console.Write("Caractere de aquecimento: ");
        string caracter = Console.ReadLine();

        alimentos.Add(new Alimento(nome, tempoAquecimento, potencia, caracter));

        Console.WriteLine("Novo alimento adicionado com sucesso!");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        ExibirAlimentos(alimentos);
    }

    private static void ExibirAlimentos(List<Alimento> alimentos)
    {
        foreach (Alimento alimento in alimentos)
        {
            Console.WriteLine($"Nome: {alimento.Nome}");
        }

        Console.WriteLine("\n1 - Para utilizar alguma função");
        Console.WriteLine("2 - para adicionar uma nova funcionalidade");
        Console.WriteLine("3 - Para voltar ao modo manual");
        Console.WriteLine("\n");
        Console.Write("Informe a opção escolhida: ");

        int opcao = ObterOpcaoValida(1, 3);

        switch (opcao)
        {
            case 1:
                bool alimentoEncontrado = false;

                do
                {
                    Console.Write("Informe o alimento desejado: ");
                    string name = Console.ReadLine();

                    if (alimentos.Any(a => a.Nome.Equals(name, StringComparison.OrdinalIgnoreCase)))
                    {
                        alimentoEncontrado = true;
                        BuscarAlimento(alimentos, name);
                    }
                    else
                    {
                        Console.WriteLine("Alimento não encontrado na lista. Por favor, informe novamente.");
                    }

                } while (!alimentoEncontrado);

                break;
            case 2:
                AdicionarNovoAlimento(alimentos);
                break;
            case 3:
                Console.Clear();
                new Interface().ExibirOpcoesDeAlimetosDisponiveis();
                break;
        }
    }

    private static int ObterOpcaoValida(int min, int max)
    {
        int opcao;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < min || opcao > max)
            {
                Console.WriteLine("Opção inválida. Por favor, insira uma opção válida.");
            }
            else
            {
                return opcao;
            }
        } while (true);
    }

    private static int ObterValorInteiroValido(string mensagem, int min, int max)
    {
        int valor;
        do
        {
            Console.Write(mensagem);
            string input = Console.ReadLine()!;
            if (!int.TryParse(input, out valor) || valor < min || valor > max)
            {
                Console.WriteLine("Valor inválido. Por favor, insira um número entre " + min + " e " + max + ".");
            }
            else
            {
                return valor;
            }
        } while (true);
    }
}




