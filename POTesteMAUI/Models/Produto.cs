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
        public int UsoMateriaPrima1 { get; set; }
        public int UsoMateriaPrima2 { get; set; }
        public int MP1Total { get; set; }
        public int MP2Total { get; set; }
        public double Lucro { get; set; }

        public Produto(string nome, double valor, int usoMP1, int usoMP2)
        {
            Nome = nome;
            Valor = valor;
            UsoMateriaPrima1 = usoMP1;
            UsoMateriaPrima2 = usoMP2;
        }
        public void AddLucro()
        {
            Lucro = this.Valor * this.Quantidade;
        }
    }
}
