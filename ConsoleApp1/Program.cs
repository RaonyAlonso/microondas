using System.Text;
using System;
using System.Collections.Generic;


void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine(@"
███╗░░░███╗██╗░█████╗░██████╗░░█████╗░  ░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
████╗░████║██║██╔══██╗██╔══██╗██╔══██╗  ██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔════╝
██╔████╔██║██║██║░░╚═╝██████╔╝██║░░██║  ██║░░██║██╔██╗██║██║░░██║███████║╚█████╗░
██║╚██╔╝██║██║██║░░██╗██╔══██╗██║░░██║  ██║░░██║██║╚████║██║░░██║██╔══██║░╚═══██╗
██║░╚═╝░██║██║╚█████╔╝██║░░██║╚█████╔╝  ╚█████╔╝██║░╚███║██████╔╝██║░░██║██████╔╝
╚═╝░░░░░╚═╝╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░  ░╚════╝░╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═════╝░");

}

void ExibirOpçõesDeAlimetosDisponiveis()
{
    Console.WriteLine("\nDigite 1 para iniciar o modo manual");
    Console.WriteLine("Digite 2 para o inicio instantanio");
    Console.WriteLine("Digite 3 pra as opções pre definadas");
    Console.WriteLine("Digite 3 pra esquentar a carne");
    Console.WriteLine("Digite 4 pra esquentar o bolo");
    Console.WriteLine("Digite 5 para adicionar uma nova configuração");

    Console.Write("\nDigite a sua opção: ");

    string opcaoEscolhida = Console.ReadLine()!;

    int opcao;
    if (!int.TryParse(opcaoEscolhida, out opcao))
    {
        Console.WriteLine("Opção inválida. Por favor, insira um númesro válido."); 
        return;
    }
    switch (opcao)
    {
        case 1:
            Console.Clear();
            ExibirMensagemDeBoasVindas();
            ParametrizaçãoTempoEPotencia();
            break;

        case 2:
            TimeSpan rapido = TimeSpan.FromSeconds(30);
            //TempoDeFuncinamento(rapido);
            break;
        case 3:
            Console.Clear();
            ExibirMensagemDeBoasVindas();
            Console.WriteLine(" 1 - Frango");
            Console.WriteLine(" 2 - Bacon");
            Console.WriteLine(" 3 - Bife");
            Console.WriteLine(" 4 - Pizza");
            Console.WriteLine(" 5 - Lasanha");

            Console.Write("Digite a opção escolhida: ");
            string name = Console.ReadLine()!;


           
                        
            

            break;


            case 4:
            Console.Clear();
            ListaAlimetos();
            break;
        

           
    }

}


  void ParametrizaçãoTempoEPotencia()
{

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
static void TempoDeFuncinamento(TimeSpan tempoTotal, int potencia = 8, string carcter = ("."))
{

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



}


ExibirMensagemDeBoasVindas();
ExibirOpçõesDeAlimetosDisponiveis();

static void ListaAlimetos()
{
    
    
    Console.WriteLine(" 1 - Frango");
    Console.WriteLine(" 2 - Bacon");
    Console.WriteLine(" 3 - Bife");
    Console.WriteLine(" 4 - Pizza");
    Console.WriteLine(" 5 - Lasanha");

    List<Alimeto> alimentos = new List<Alimeto>
    {
        new Alimeto("Frango", 50, 5, "&"),
        new Alimeto("Bacon", 120, 3, "x"),
        new Alimeto("Bife", 60, 2, "*"),
        new Alimeto("Pizza", 2, 1, "#"),
        new Alimeto("Lasanha", 90, 4, "!"),
    };
   
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
}



  




static void BuscaDeAlimentos(List<Alimeto> lista, string nomeDesejado)
{
    foreach (Alimeto alimeto in lista)
    {
        if (alimeto.Nome.Equals(nomeDesejado, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"\nO alimento escolhido foi: {nomeDesejado} Nivel de aquecimento: {alimeto.Potencia} tempo estimado: {TimeSpan.FromSeconds(alimeto.TempoDeAquecimento):mm\\:ss}");
            Console.WriteLine("\n");
            Console.Write("\nCaso deseje esquentar esse alimento precione a tecla 1: ");
            Console.Write("\nCaso deseje consultar as opções navamente tecle 2: ");
            string opcaoEscolhida = Console.ReadLine()!;

            int opcao;
            if (!int.TryParse(opcaoEscolhida, out opcao))
            {
                Console.WriteLine("Opção inválida. Por favor, insira um númesro válido.");
                return;
            }

            switch (opcao)
            {
                 case 1:
                 TempoDeFuncinamento(TimeSpan.FromSeconds(alimeto.TempoDeAquecimento), alimeto.Potencia, alimeto.Carcter);
                    break;

                 case 2:
                    ListaAlimetos();
                    break;
            }




            break;
        }     
    }

    

    
}   

class Alimeto
{
    public string Nome { get; }
    public int TempoDeAquecimento { get; }
    public int Potencia { get; }
    public string Carcter { get; }

    public Alimeto(string nome, int TempoDeAquecimento, int Potencia, string Caracter)
    {
        this.Nome = nome;
        this.Potencia = Potencia;
        this.TempoDeAquecimento = TempoDeAquecimento;
        this.Carcter = Caracter;
    }

}



    














