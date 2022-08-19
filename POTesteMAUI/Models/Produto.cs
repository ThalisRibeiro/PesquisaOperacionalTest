using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POTesteMAUI.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public int UsoHH { get; set; }
        public int UsoHm { get; set; }

        public Produto(string nome, double valor, int quantidade, int usoHH, int usoHm)
        {
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
            UsoHH = usoHH;
            UsoHm = usoHm;
        }
    }
}
