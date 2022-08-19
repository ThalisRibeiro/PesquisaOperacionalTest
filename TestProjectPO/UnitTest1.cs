using System.Diagnostics;
using Xunit;

namespace TestProjectPO
{
    public class UnitTest1
    {
        [Fact]
        public void ComparadorExemploFaculdade()
        {
            //esperado
            POTesteMAUI.Models.Produto p1e = new("produto 1", 4, 1, 9, 3);
            POTesteMAUI.Models.Produto p2e = new("produto 2", 1, 9, 1, 1);
            //teste
            POTesteMAUI.Models.Empresa e = new(18,12) ;
            POTesteMAUI.Models.Produto p1 = new("produto 1",4,0,9,3) ;
            POTesteMAUI.Models.Produto p2 = new("produto 2", 1, 0, 1, 1);
            POTesteMAUI.Models.Verificador v = new(e,ref p1,ref p2);
            //Console.WriteLine($"Valor final{v.ValorMaisAlto}");
            //resultados
            Assert.Equal(p1e.Quantidade, p1.Quantidade);
            Assert.Equal(p2e.Quantidade, p2.Quantidade);

        }
    }
}