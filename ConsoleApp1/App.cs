using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class App
    {
        static void Main()
        {
            try
            {
                MenuPrincipal usuario = new MenuPrincipal();
                usuario.ExibirOpcoesDeAlimetosDisponiveis();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                
            }
        }
    }
}
