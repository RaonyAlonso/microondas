using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Microondas
{
    public void ParametrizacaoTempoEPotencia()
    {
        Interface usuario = new Interface();
        Console.WriteLine("Digite o tempo desejado em segundos (mínimo 1 segundo, máximo 120 segundos - equivalente a 2 minutos):");
        int tempoSegundos;
        do
        {
            Console.Write("Tempo desejado: ");
            string input = Console.ReadLine()!;

            if (!int.TryParse(input, out tempoSegundos))
            {
                Console.WriteLine("Por favor, insira um número válido.");
                continue;
            }

            if (tempoSegundos < 1 || tempoSegundos > 120)
            {
                Console.WriteLine("Por favor, insira um valor entre 1 e 120 segundos.");
                continue;
            }

            break;

        } while (true);

        int potencia = 10;
        do
        {
            Console.Write("Digite a potência: ");

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

        TimeSpan tempo = TimeSpan.FromSeconds(tempoSegundos);

        Aquecer(tempo, potencia);
    }

    public void Aquecer(TimeSpan tempoTotal, int potencia = 10, string caracterAquecimento = ".")
    {
        bool pausado = false;
        bool cancelado = false;
        Interface usuario = new Interface();

        int segundosTotais = (int)tempoTotal.TotalSeconds;
        StringBuilder sb = new StringBuilder();

        for (int segundos = segundosTotais; segundos >= 0; segundos--)
        {
            Console.WriteLine("Caso deseja pausar precione a tecla P");
            Console.WriteLine($"Tempo restante: {TimeSpan.FromSeconds(segundos):mm\\:ss}");

            Console.WriteLine(sb.ToString());
            for (int i = 0; i < potencia; i++)
            {
                sb.Append(caracterAquecimento);
            }

            while (pausado)
            {
                Console.WriteLine("Pausado. Pressione 'C' para continuar ou 'X' para cancelar.");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.KeyChar)
                {
                    case 'C':
                    case 'c':
                        Console.WriteLine("Continuando...");
                        pausado = false;
                        break;
                    case 'X':
                    case 'x':
                        Console.WriteLine("Cancelado pelo usuário.");
                        cancelado = true;
                        pausado = false;
                        break;
                }
            }

            if (cancelado)
            {
                ExibirMenuAposAquecimento(usuario);
                return;
            }

            Thread.Sleep(1000);

            Console.Clear();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.KeyChar == 'P' || keyInfo.KeyChar == 'p')
                {
                    pausado = true;
                }
            }
        }

        Console.WriteLine("Aquecido!");
        ExibirMenuAposAquecimento(usuario);
    }

    public void Automatico()
    {
        TimeSpan rapido = TimeSpan.FromSeconds(30);
        Aquecer(rapido, 8);
    }

    private void ExibirMenuAposAquecimento(Interface usuario)
    {
        try
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            usuario.ExibirOpçõesDeAlimetosDisponiveis();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro ao exibir o menu: " + ex.Message);
            
        }
    }
}

