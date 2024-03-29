﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Alimento
  
{
   
    public void ListaAlimetos()
    {
        ExibirAlimentos(alimentos);
    }
    static void BuscaDeAlimentos(List<Alimeto> lista, string nomeDesejado)
    {

        foreach (Alimeto alimeto in lista)
        {
            Interface usuario = new Interface();
            if (alimeto.Nome.Equals(nomeDesejado, StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine($"\n O alimento escolhido foi: {nomeDesejado}\n Nivel de aquecimento programado: {alimeto.Potencia} \n Tempo definido: {TimeSpan.FromSeconds(alimeto.TempoDeAquecimento):mm\\:ss}");
                Console.WriteLine("\n");
                Console.WriteLine("Caso deseje preparar o alimento escolhido tecle 1: ");
                Console.WriteLine("Caso deseje consultar as opções novamente tecle 2: ");
                Console.WriteLine("caso deseje voltar para o modo manual tecle 3");
                Console.Write("\nInforme a opção escolhida: ");
                int opcao;
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out opcao) || (opcao != 1 && opcao != 2 && opcao != 3))
                    {
                        Console.WriteLine("Opção inválida. Por favor, insira uma opção válida.");
                    }
                    else
                    {
                        break; 
                    }
                } while (true);

                switch (opcao)
                {
                    case 1:
                        Microondas microondas1 = new Microondas();
                        microondas1.TempoDeFuncinamento(TimeSpan.FromSeconds(alimeto.TempoDeAquecimento), alimeto.Potencia, alimeto.Carcter);
                        break;

                    case 2:
                        Console.Clear();
                        ExibirAlimentos(lista);
                        break;
                    case 3:
                        Console.Clear();
                        usuario.ExibirOpçõesDeAlimetosDisponiveis();
                        break;


                }




                break;
            }
        }




    }
    static void AdicionarNovoAlimento(List<Alimeto> alimentos)
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

        int tempoAquecimento;
        do
        {
            Console.Write("Tempo de aquecimento (em segundos, entre 1 e 120): ");
            string tempoAquecimentoStr = Console.ReadLine();
            if (!int.TryParse(tempoAquecimentoStr, out tempoAquecimento) || tempoAquecimento < 1 || tempoAquecimento > 120)
            {
                Console.WriteLine("Valor não reconhecido");
            }
            else
            {
                break;
            }
        } while (true);

        int potencia = 10;
        do
        {
            Console.Write("Nível da potência: ");
            string potenciaStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(potenciaStr))
            {
                break;
            }
            else if (!int.TryParse(potenciaStr, out potencia) || potencia < 1 || potencia > 10)
            {
                Console.WriteLine("Nível inválido. Por favor, insira um valor inteiro entre 1 e 10.");
            }
            else
            {
                break;
            }
        } while (true);

        Console.Write("Caractere de aquecimento: ");
        string caracter = Console.ReadLine();

        alimentos.Add(new Alimeto(nome, tempoAquecimento, potencia, caracter));

        Console.WriteLine("Novo alimento adicionado com sucesso!");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        ExibirAlimentos(alimentos);
    }
    static void ExibirAlimentos(List<Alimeto> alimentos)
    {
        Interface usuario = new Interface();
        foreach (Alimeto alimento in alimentos)
        {
            Console.WriteLine($"Nome: {alimento.Nome}");
        }
        Console.WriteLine("\n1 - Para utilizar alguma função");
        Console.WriteLine("2 - para adicionar uma nova funcionalidade");
        Console.WriteLine("3 - Para voltar ao modo manual");
        Console.WriteLine("\n");
        Console.Write("Informe a opção escolhida: ");
        int opcao;

        do
        {
            if (!int.TryParse(Console.ReadLine(), out opcao) || (opcao != 1 && opcao != 2 && opcao != 3))
            {
                Console.WriteLine("Opção inválida. Por favor, insira uma opção válida.");
            }
            else
            {
                break;
            }
        } while (true);
        switch (opcao)
        {
            case 1:
                bool alimentoEncontrado = false;
                string nomeAlimento = "";

                do
                {
                    Console.Write("Informe o alimeto desejado: ");
                    string name = Console.ReadLine();

                    foreach (var alimeto in alimentos)
                    {
                        if (alimentos.Any(a => a.Nome.Equals(name, StringComparison.OrdinalIgnoreCase)))
                        {
                            alimentoEncontrado = true;
                            BuscaDeAlimentos(alimentos, name);
                            break;
                        }
                    }

                    if (!alimentoEncontrado)
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
                usuario.ExibirOpçõesDeAlimetosDisponiveis();
                break;
        }

    }
       
    class Alimeto
    {
        public string Nome { get; }
        public int TempoDeAquecimento { get; }
        public int Potencia { get; }
        public string Carcter { get; }

        public Alimeto(string nome, int tempoDeAquecimento, int potencia, string caracter)
        {
            Nome = nome;
            Potencia = potencia;
            TempoDeAquecimento = tempoDeAquecimento;
            Carcter = caracter;
        }
    }
    List<Alimeto> alimentos = new List<Alimeto>
    {
        new Alimeto("Frango", 50, 5, "&"),
        new Alimeto("Bacon", 120, 3, "x"),
        new Alimeto("Bife", 60, 2, "*"),
        new Alimeto("Pizza", 2, 1, "#"),
        new Alimeto("Lasanha", 90, 4, "!"),
    };

}



