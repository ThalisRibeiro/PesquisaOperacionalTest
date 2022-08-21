﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Shapes;
using POTesteMAUI.Services;

namespace POTesteMAUI.Models
{

    public class Verificador
    {
        readonly IMessage _message;
        public double ValorMaisAlto { get; private set; }
        //double ValorMaisAlto = 0;
        int maiorI1;
        int maiorI2;
        int maiorI3;
        bool deuerro;

        public Verificador(Empresa empresa, ref Produto produto, ref Produto produto2)
        {
            //_message = DependencyService.Get<Services.IMessage>();
            _message = DependencyService.Get<IMessage>();
            TesteErro(empresa,produto,produto2);
            if (deuerro)
                return;
            Comparador(empresa, ref produto, ref produto2);
        }

        private void TesteErro(Empresa empresa,Produto produto, Produto produto1, Produto produto2 = null)
        {
            if (produto2 ==null)
            {

                if (empresa.MateriaPrima1 < 1 || empresa.MateriaPrima2 < 1)
                {
                    deuerro = true;
                    _message.MostraMensagemErro("ERRO", "quantidade de materia prima disponivel nao elegivel");
                    return;
                    //erro: quantidade de materia prima disponivel nao elegivel
                }
                if (produto.Valor < 1 || produto1.Valor < 1 || produto.UsoMateriaPrima1 < 1 || produto1.UsoMateriaPrima1 < 1
                    || produto.UsoMateriaPrima2 < 1 || produto1.UsoMateriaPrima2 < 1)
                {
                    deuerro = true;
                    _message.MostraMensagemErro("ERRO", "valores dos produtos nao aceitos, verifique se todos sao maiores de 0");
                    return;
                    //erro: valores dos produtos nao aceitos, verifique se todos sao maiores de 0

                }
            }
            else
            {

                if (empresa.MateriaPrima1 < 1 || empresa.MateriaPrima2 < 1)
                {
                    deuerro = true;
                    _message.MostraMensagemErro("ERRO", "quantidade de materia prima disponivel nao elegivel");
                    return;
                    //erro: quantidade de materia prima disponivel nao elegivel
                }
                if (produto.Valor < 1 || produto1.Valor < 1 || produto2.Valor<1 ||produto.UsoMateriaPrima1 < 1 || produto1.UsoMateriaPrima1 < 1
                    || produto2.UsoMateriaPrima1<1 ||produto.UsoMateriaPrima2 < 1 || produto1.UsoMateriaPrima2 < 1 ||produto2.UsoMateriaPrima2<1)
                {
                    deuerro = true;
                    _message.MostraMensagemErro("ERRO", "valores dos produtos nao aceitos, verifique se todos sao maiores de 0");
                    return;
                    //erro: valores dos produtos nao aceitos, verifique se todos sao maiores de 0

                }
            }
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
