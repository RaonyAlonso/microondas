using System.Text;
using System;
using System.Collections.Generic;




public class Interface
{
    
   
    public void ExibirOpçõesDeAlimetosDisponiveis()
    {
        Console.Clear();
        Alimento alimento = new Alimento();
        Microondas microondas = new Microondas();
        Console.WriteLine(@"
███╗░░░███╗██╗░█████╗░██████╗░░█████╗░  ░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
████╗░████║██║██╔══██╗██╔══██╗██╔══██╗  ██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔════╝
██╔████╔██║██║██║░░╚═╝██████╔╝██║░░██║  ██║░░██║██╔██╗██║██║░░██║███████║╚█████╗░
██║╚██╔╝██║██║██║░░██╗██╔══██╗██║░░██║  ██║░░██║██║╚████║██║░░██║██╔══██║░╚═══██╗
██║░╚═╝░██║██║╚█████╔╝██║░░██║╚█████╔╝  ╚█████╔╝██║░╚███║██████╔╝██║░░██║██████╔╝
╚═╝░░░░░╚═╝╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░  ░╚════╝░╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═════╝░");


        int opcao;

        do
        {
            Console.WriteLine("\nDigite 1 para iniciar o modo manual");
            Console.WriteLine("Digite 2 para o inicio instantâneo");
            Console.WriteLine("Digite 3 para as opções pré definidas");
            Console.WriteLine("Digite 4 para sair do programa");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine();

            if (!int.TryParse(opcaoEscolhida, out opcao) || opcao < 1 || opcao > 4)
            {
                Console.WriteLine("Opção inválida. Por favor, insira um número válido de 1 a 4.");
            }
            else
            {
                break;
            }
        } while (true);

        switch (opcao)
        {
            case 1:
                Console.Clear();
                microondas.ParametrizacaoTempoEPotencia();
                break;

            case 2:
                microondas.Automatico();
                break;
            case 3:
                Console.Clear();
                alimento.ListaAlimetos();

                break;

            case 4:

                break;



        }

    }

}



 






    














