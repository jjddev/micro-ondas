using Micro_ondas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Micro_ondas2
{
    class Program
    {

        static void Main(string[] args)
        {

            var micro = new Microondas();
            var programaInvalido = true;
            var programas = micro.ListarProgramas();
            string opcao = "5";

            while (opcao != "0") {
                MenuPrincipal();
                Console.WriteLine("");


                opcao = Console.ReadLine();

                if (opcao == "0")
                {
                    Environment.Exit(0);
                }
                else if (opcao == "1")
                {
                    ListarProgramas(programas);
                }
                else if (opcao == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Informe a palavra chave para pesquisa:");
                    var palavraChave = Console.ReadLine();

                    var itens = programas.Where(p => p.Compatibilidade.Contains(palavraChave.ToLower())).ToList();
                    ListarProgramas(itens);

                }
                else if (opcao == "3")
                {
                    micro.AdicionarPrograma(NovoPrograma());
                    programas = micro.ListarProgramas();
                }
                else if (opcao == "4")
                {

                    Console.WriteLine("Digite o nome do alimento");
                    string alimento = Console.ReadLine().ToLower();

                    var programa = programas.Where(p => p.Compatibilidade.Contains(alimento)).FirstOrDefault();

                    while (programaInvalido)
                    {
                        if (programa == null)
                        {

                            try
                            {
                                programa = CriarProgramaValido();
                            }
                            catch (ArgumentOutOfRangeException e)
                            {
                                Console.WriteLine("Aviso: " + e.ParamName);
                            }
                            catch (InvalidCastException e)
                            {
                                Console.WriteLine("Aviso: " + e.Message);
                            }
                        }
                        else
                        {
                            programaInvalido = false;
                        }
                    }
                    micro.Aquecer(programa);
                    Console.ReadKey();
                }
            }
        }


        public static Programa CriarProgramaValido()
        {
            return new Programa(LerTempo(), LerPotencia());
        }



        public static int LerTempo()
        {
            Console.WriteLine("Informe o tempo de cozimento (em segundos): ");

            if (int.TryParse(Console.ReadLine(), out int tempo))
            {
                return tempo;
            }
            else
            {
                throw new InvalidCastException("Entrada inválida para tempo");
            }

        }

        public static int LerPotencia()
        {
            Console.WriteLine("Informe a potencia (valor entre 1 e 10): ");

            if (int.TryParse(Console.ReadLine(), out int potencia))
            {
                return potencia;
            }
            else
            {
                throw new InvalidCastException("Entrada inválida potencia");
            }
        }

        public static void ReiniciarProcesso()
        {
            Console.WriteLine("");
            Console.WriteLine("Processo reiniciado");
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Programas Disponiveis");
            Console.WriteLine("2 - Pequisar Programas");
            Console.WriteLine("3 - Criar Novo Programa");
            Console.WriteLine("4 - Aquecer/Ligar");
        }

        public static void ListarProgramas(IList<Programa> programas)
        {
                Console.Clear();
                Console.WriteLine("Programas disponíveis");
                foreach (var item in programas)
                {
                    Console.WriteLine("Nome: {0}| Instrucoes: {1}| Tempo: {2}| Potência: {3} ", item.Nome, item.Instrucoes, item.Tempo, item.Potencia);
                }
            }

        public static Programa NovoPrograma()
        {
            int tempo = 0;
            int potencia = 0;
            var p = new Programa();

            Console.WriteLine("Informe o nome do programa:");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe as instrucoes:");
            string instrucoes = Console.ReadLine();

            Console.WriteLine("Informe o simbolo de aquecimento");
            string simbolo = Console.ReadLine();

            try
            {
                Console.WriteLine("Informe o tempo:");
                int.TryParse(Console.ReadLine(), out  tempo);

                Console.WriteLine("Informa a potencia");
                int.TryParse(Console.ReadLine(), out  potencia);


                 p = new Programa { Nome = nome, Instrucoes = instrucoes, Tempo = tempo, Potencia = potencia, Simbolo = simbolo.First() };

                
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Aviso: " + e.ParamName);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Aviso: " + e.Message);
            }

            return p;
        }
    }
}



