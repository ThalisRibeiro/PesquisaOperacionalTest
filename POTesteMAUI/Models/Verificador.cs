using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POTesteMAUI.Models
{

    public class Verificador
    {
        public double ValorMaisAlto { get; private set; }
        //double ValorMaisAlto = 0;
        int maiorI1;
        int maiorI2;

        public Verificador(Empresa empresa, ref Produto produto, ref Produto produto2)
        {
            Comparador(empresa, ref produto, ref produto2);
        }
        //ele multiplica os valores, verifica se não ultrapassa as horas maximas e se foi o maior valor
         void Comparador(Empresa empresa, ref Produto produto, ref Produto produto2)
        {
            int i1 = 0;
            int i2 = 0;
            do
            {
                do
                {
                    var hhTotais= produto.UsoMateriaPrima1 *i1 +produto2.UsoMateriaPrima1 * i2;
                    var hmTotais = produto.UsoMateriaPrima2 *i1 +produto2.UsoMateriaPrima2 *i2;
                    if (hhTotais > empresa.MateriaPrima1 || hmTotais > empresa.MateriaPrima2)
                        break;

                    var valorTotal = produto.Valor * i1 + produto2.Valor *i2;
                    if (valorTotal > ValorMaisAlto)
                    {
                        ValorMaisAlto = valorTotal;
                        maiorI1 = i1;
                        maiorI2 = i2;
                    }
                    i2 += 1;
                } while (true);

                if (i2 == 0)
                    break;

                i1++;
                i2 = 0;

            } while (true);
            produto.Quantidade = maiorI1;
            produto2.Quantidade = maiorI2;
        }
    }
}
