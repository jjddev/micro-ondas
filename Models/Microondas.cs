using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Micro_ondas2.Models
{
    public class Microondas
    {
        private IList<Programa> Programas = new List<Programa>();
        private static int contador = 0;
        private static System.Timers.Timer timer = new System.Timers.Timer(1000);
        private Programa _programa;

        public Microondas()
        {
            Programas.Add(new Programa { Id = 1, Nome = "massas", Instrucoes = "Adicione a lasanha congelada....", Potencia = 10, Tempo = 5, Simbolo = '+', Compatibilidade = "pizza lasanha" });
            Programas.Add(new Programa { Id = 2, Nome = "pipoca", Instrucoes = "Abra o pacote...", Potencia = 2, Tempo = 3, Simbolo = '*', Compatibilidade = "pipoca doce salgada" });
            Programas.Add(new Programa { Id = 3, Nome = "legumes", Instrucoes = "Adicione água ao legumes...", Potencia = 3, Tempo = 5, Simbolo = '@', Compatibilidade = "cenoura berinjela abobrinha" });
            Programas.Add(new Programa { Id = 4, Nome = "leite", Instrucoes = "Coloque o leite e adicione chocoalte...", Potencia = 5, Tempo = 3, Simbolo = '%', Compatibilidade = "leite nescau toddy nescafe" });
            Programas.Add(new Programa { Id = 5, Nome = "carnes brancas", Instrucoes = "Frango ao molho....", Potencia = 4, Tempo = 3, Simbolo = '^', Compatibilidade = "peixe frango camarao" });
            Programas.Add(new Programa { Id = 6, Nome = "inicio rapido", Instrucoes = "inicio rapido", Potencia = 8, Tempo = 30, Simbolo = '#', Compatibilidade = "agua sanduiche queijo pao carne pendrive" });
            Programas.Add(new Programa { Id = 6, Nome = "explosao", Instrucoes = "coloque e saia correndo", Potencia = 10, Tempo = 120, Simbolo = '½', Compatibilidade = "metal garfo colher celular" });
        }

        public void AdicionarPrograma(Programa p)
        {
            Programas.Add(p);
        }

        public IList<Programa> ListarProgramas()
        {
            return Programas;
        }

        public void Aquecer(Programa programa)
        {
            _programa = programa;
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {

            Console.Write(new string(_programa.Simbolo, _programa.Potencia));
            contador++;

            if (contador == _programa.Tempo)
            {
                timer.Enabled = false;
                Console.Write("Aquecida");
            }
        }
    }

}

