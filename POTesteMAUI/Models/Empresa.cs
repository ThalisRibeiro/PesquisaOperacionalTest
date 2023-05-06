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
        public List<double> RestricoesList
        {
            get
            {
                var list = new List<double>();
                list.Add(MateriaPrima1);
                list.Add(MateriaPrima2);
                return list;
            }
        }
        public string NomeMateriaPrima1 { get; set; }
        public string NomeMateriaPrima2 { get; set; }
        public int MP1Usada { get; set; }
        public int MP2Usada { get; set; }
        public double LucroToral { get; set; }
        public Empresa(int mp1Disponivel, int mp2Disponivel, string nMP1,string nMP2)
        {
            MateriaPrima1 = mp1Disponivel;
            MateriaPrima2 = mp2Disponivel;
            NomeMateriaPrima1 = nMP1;
            NomeMateriaPrima2 = nMP2;
        }
    }
}
