using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POTesteMAUI.Models
{
    public class Empresa
    {
        public int MateriaPrima1 { get; set; }
        public int MateriaPrima2 { get; set; }
        public string NomeMateriaPrima1 { get; set; }
        public string NomeMateriaPrima2 { get; set; }
        public Empresa(int mp1Disponivel, int mp2Disponivel)
        {
            MateriaPrima1 = mp1Disponivel;
            MateriaPrima2 = mp2Disponivel;
        }
    }
}
