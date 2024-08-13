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
                Interface usuario = new Interface();
                usuario.ExibirOpcoesDeAlimetosDisponiveis();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                
            }
        }
    }
}
