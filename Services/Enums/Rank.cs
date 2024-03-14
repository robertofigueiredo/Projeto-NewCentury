using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Enums
{
    public class Rank
    {
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public string Descricao { get; set; }

        public Rank(int minimo, int maximo, string descricao)
        {
            Minimo = minimo;
            Maximo = maximo;
            Descricao = descricao;
        }
    }

}
