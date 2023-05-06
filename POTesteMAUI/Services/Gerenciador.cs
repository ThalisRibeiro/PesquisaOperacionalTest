using POTesteMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POTesteMAUI.Services
{
    public class Gerenciador
    {
        public Gerenciador(Empresa empresaRecebida, List<Produto> produtosRecebidos)
        {
            this.empresa = empresaRecebida;
            this.produtos = produtosRecebidos;
        }
        public Empresa empresa;
        public List<Produto> produtos;

    }
}
