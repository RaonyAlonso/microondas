using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Microondas
    {
    
   public void ParametrizaçãoTempoEPotencia()
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

        int pontencia;
        do
        {
            Console.Write("Digite a potência: ");
            string input = Console.ReadLine()!;



            if (!int.TryParse(input, out pontencia))
            {
                Console.WriteLine("Por favor, insira um número válido.");
                continue;
            }

            if (pontencia < 1 || pontencia > 10)
            {
                Console.WriteLine("Por favor, insira um valor de 1 a 10.");
                continue;
            }
            break;
        } while (true);


        TimeSpan tempo = TimeSpan.FromSeconds(tempoSegundos);

        TempoDeFuncinamento(tempo, pontencia);



    }
   public  void TempoDeFuncinamento(TimeSpan tempoTotal , int potencia = 8, string carcter = ("."))
    {
        Interface usuario = new Interface();

        int segundosTotais = (int)tempoTotal.TotalSeconds;
        StringBuilder sb = new StringBuilder();



        for (int segundos = segundosTotais; segundos >= 0; segundos--)
        {
            Console.WriteLine($"Tempo restante: {TimeSpan.FromSeconds(segundos):mm\\:ss}");

            Console.WriteLine(sb.ToString());
            for (int i = 0; i < potencia; i++)
            {
                sb.Append(carcter);


            }

            Thread.Sleep(1000);

            Console.Clear();

        }

        Console.WriteLine("Aquecida ");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
        usuario.ExibirOpçõesDeAlimetosDisponiveis();


    }

    public void Automatico()
    {
        TimeSpan rapído = TimeSpan.FromSeconds(30);
        TempoDeFuncinamento(rapído);
    }

   
}

