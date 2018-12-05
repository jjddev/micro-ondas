using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_ondas2.Models
{
    public class Programa
    {

        private int _Tempo;
        private int _Potencia = 10;

        public int Tempo { get { return _Tempo; } set { ValidarTempo(value); } }
        public int Potencia { get { return _Potencia; } set { ValidarPotencia(value); } }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Instrucoes { get; set; }
        public char Simbolo { get; set; }
        public string Compatibilidade { get; set; }

        public Programa(int tempo, int potencia)
        {
            ValidarTempo(tempo);
            ValidarPotencia(potencia);
        }

        public Programa()
        {
        }

        private void ValidarTempo(int tempo)
        {
            if (tempo > 0 && tempo < 121)
            {
                _Tempo = tempo;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Informe um valor dentro do intervalo de 1 segundo até 2 minutos.");
            }
        }

        public void ValidarPotencia(int potencia)
        {

            if (potencia > 0 && potencia < 11)
            {
                _Potencia = potencia;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Potencia fora do intervalo. Informe um numero entre 1 e 10");
            }
        }
    }
}
