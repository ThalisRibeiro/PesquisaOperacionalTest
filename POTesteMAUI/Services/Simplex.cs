using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POTesteMAUI.Services
{
    public class Simplex
    {
        public Gerenciador gerenciador;
        private int qtdProdutos;
        private int qtdMateriasPrimas;
        public int linhas { get { return qtdMateriasPrimas + 1; } }
        public int colunas { get { return qtdProdutos + qtdMateriasPrimas + 1; } }
        public double[,] tabela;
        public Simplex(Gerenciador gerenciadorRecebido)
        {
            this.gerenciador = gerenciadorRecebido;
            verificaValores();
            this.tabela = criaTabela();
        }
        public double[,] criaTabela()
        {
            this.qtdProdutos = gerenciador.produtos.Count;
            this.qtdMateriasPrimas = 2;
            //qtd de restrições mais 1 para valores
            int linhas = qtdMateriasPrimas + 1;
            //é a qtd de produtos mais a qtd de materias primas ou restrições + 1 para os valores
            int colunas = qtdProdutos + qtdMateriasPrimas + 1;
            double[,] tabela = new double[linhas, colunas];
            return alimentaTabela(linhas, colunas, tabela);
        }

        void verificaValores()
        {
            bool possuiDiferenteDeZero = false;
            for (int i = 0; i < gerenciador.empresa.RestricoesList.Count; i++)
            {
                if (gerenciador.empresa.RestricoesList[i]==0)
                {
                    throw new Exception("Nao foi inserido as devidas restrições");
                }
            }
            foreach (var produto in gerenciador.produtos)
            {
                foreach (var gasto in produto.GastoDasMP)
                {
                    if (gasto != 0) possuiDiferenteDeZero = true;                  
                }
                if (possuiDiferenteDeZero == false)
                {
                    throw new Exception("Possui produto sem gastos");
                }
            }
        }
        //Metodo que leva em conta como se a quantidade de produtos e restrições fossem aleatórias por lista
        public double[,] alimentaTabela(int linhas, int colunas, double[,] tabela)
        {
            for (int i = 0; i < linhas; i++)
            {
                //Alimentando a linha final Z
                if (i == linhas - 1)
                {
                    for (int z = 0; z < colunas; z++)
                    {
                        if (z < qtdProdutos)
                        {
                            tabela[i, z] = gerenciador.produtos[z].Valor * -1;
                            //break;
                        }
                        else
                            tabela[i, z] = 0;
                    }

                    break;
                }
                //Alimentando linhas do topo
                for (int z = 0; z < colunas; z++)
                {
                    //Valor da solução
                    if (z == colunas - 1)
                    {
                        tabela[i, z] = gerenciador.empresa.RestricoesList[i];
                        continue;
                    }
                    //Variavel de decisao x1, x2....
                    if (z < qtdProdutos)
                    {
                        tabela[i, z] = gerenciador.produtos[z].GastoDasMP[i];
                        continue;
                    }
                    // Quando F bate o mesmo numero linha coluna F1 F1 / F2 F2 
                    if (z == qtdProdutos + i)
                    {
                        tabela[i, z] = 1;
                        continue;
                    }

                    tabela[i, z] = 0;
                }
            }
            PrintaTabela(linhas, colunas, tabela);
            Console.WriteLine($"Fim do alimenta Tabela");
            return tabela;
        }

        private static void PrintaTabela(int linhas, int colunas, double[,] tabela)
        {
            for (int i = 0; i < linhas; i++)
            {
                if (i == linhas - 1)
                {
                    Console.Write("Z\t");
                }
                else
                    Console.Write($"F{i + 1}\t");

                for (int z = 0; z < colunas; z++)
                {
                    Console.Write($"{tabela[i, z].ToString("0.###")}\t");
                }
                Console.Write("\n");
            }
        }

        //Metodos para encontro de pivo
        public Gerenciador RodaSimplex()
        {
            do
            {
                int colunaMenorValor = buscaColunaPivo(this.tabela, this.linhas, this.colunas, this.qtdProdutos);
                int linhaMenorValor = buscaLinhaPivo(this.tabela, this.linhas, this.colunas, colunaMenorValor);
                double[,] novaTabela = equacaoDoPivo(this.tabela, this.colunas, colunaMenorValor, linhaMenorValor);
                Console.WriteLine($"Tabela com Nova Equação do pivo");
                PrintaTabela(linhas, colunas, novaTabela);
                this.tabela = (double[,])equacaoDoResto(novaTabela, linhas, colunas, colunaMenorValor, linhaMenorValor).Clone();
            } while (PossuiNegativoEmZ(this.tabela));
            return RetoronaObjetosComValoresFinais();
        }

        public Gerenciador RetoronaObjetosComValoresFinais()
        {
            for (int i = 0; i < linhas - 1; i++)
            {
                for (int z = 0; z < qtdProdutos; z++)
                {
                    if (this.tabela[i, z] == 1)
                    {
                        gerenciador.produtos[z].Quantidade = (int)Math.Round(this.tabela[i, colunas - 1]);
                    }
                }
            }
            gerenciador.empresa.LucroToral = this.tabela[linhas - 1, colunas - 1];
            AdicionaValoresEmpresa();
            return gerenciador;
        }
        void AdicionaValoresEmpresa()
        {
            gerenciador.empresa.MP1Usada = 0;
            gerenciador.empresa.MP2Usada = 0;
            foreach (var produto in gerenciador.produtos)
            {
                gerenciador.empresa.MP1Usada += produto.MP1Total;
                gerenciador.empresa.MP2Usada += produto.MP2Total;
            }
            
        }

        private bool PossuiNegativoEmZ(double[,] tabela)
        {
            for (int i = 0; i < qtdProdutos; i++)
            {
                if (tabela[linhas - 1, i] < 0)
                {
                    return true;
                }
            }
            return false;
        }

        int buscaColunaPivo(double[,] tabela, int linhas, int colunas, int qtdProdutos)
        {
            int colunaMenorValor = -1;
            for (int i = 0; i < qtdProdutos; i++)
            {
                if (colunaMenorValor == -1 && tabela[linhas - 1, i] != 0)
                {
                    colunaMenorValor = i;
                    continue;
                }
                if (colunaMenorValor == -1 && tabela[linhas - 1, i] == 0)
                {
                    continue;
                }
                if (tabela[linhas - 1, i] < tabela[linhas - 1, colunaMenorValor])
                {
                    colunaMenorValor = i;
                    continue;
                }
            }
            return colunaMenorValor;
        }
        int buscaLinhaPivo(double[,] tabela, int linhas, int colunas, int colunaMenorValor)
        {
            int linhaMenorValor = -1;
            for (int i = 0; i < linhas - 1; i++)
            {
                if (tabela[i, colunaMenorValor] == 0) continue;
                if (linhaMenorValor == -1)
                {
                    linhaMenorValor = i;
                    continue;
                }
                if (isFirstQuocientLowerThanSecond(tabela[i, colunaMenorValor], tabela[i, colunas - 1],
                    tabela[linhaMenorValor, colunaMenorValor], tabela[linhaMenorValor, colunas - 1]))
                {
                    linhaMenorValor = i; continue;
                }
            }
            return linhaMenorValor;
        }
        bool isFirstQuocientLowerThanSecond(double var1, double varSol1, double var2, double varSol2)
        {
            if (varSol1 / var1 < varSol2 / var2) return true;
            return false;
        }

        double[,] equacaoDoPivo(double[,] tabela, int colunas, int colunaMenorValor, int linhaMenorValor)
        {
            double[,] tabelaNovaLinhaPivo = (double[,])tabela.Clone();
            for (int i = 0; i < colunas; i++)
            {
                if (tabelaNovaLinhaPivo[linhaMenorValor, i] == 0) continue;

                tabelaNovaLinhaPivo[linhaMenorValor, i] /= tabela[linhaMenorValor, colunaMenorValor];
            }
            return tabelaNovaLinhaPivo;
        }
        double[,] equacaoDoResto(double[,] tabela, int linhas, int colunas, int colunaMenorValor, int linhaMenorValor)
        {
            double[,] tabelaNova = (double[,])tabela.Clone();
            for (int i = 0; i < linhas; i++)
            {
                double cociente = getCociente(tabela[i, colunaMenorValor], tabela[linhaMenorValor, colunaMenorValor]);
                double[] linhaMultiplicadaPorCociente = getLinhaNovoCociente(cociente, tabela, linhaMenorValor);
                tabelaNova = (double[,])GetValoresDoResto(tabelaNova, i, linhaMenorValor, linhaMultiplicadaPorCociente).Clone();
            }
            Console.WriteLine("Apos mudar todas as equacoes");
            PrintaTabela(linhas, colunas, tabelaNova);
            return tabelaNova;
        }
        double[,] GetValoresDoResto(double[,] tabela, int linha, int linhaMenorValor, double[] linhaMultiplicadaPorCociente)
        {
            double[,] tabelaNova = (double[,])tabela.Clone();
            for (int i = 0; i < colunas; i++)
            {
                if (linha == linhaMenorValor) break;
                tabelaNova[linha, i] -= linhaMultiplicadaPorCociente[i];
            }
            Console.WriteLine($"Tabela com mudanca da linha{linha}: ");
            PrintaTabela(linhas, colunas, tabelaNova);
            return tabelaNova;
        }
        private double[] getLinhaNovoCociente(double cociente, double[,] tabela, int linhaMenorValor)
        {
            double[] linha = new double[colunas];
            for (int i = 0; i < colunas; i++)
            {
                linha[i] = tabela[linhaMenorValor, i] * cociente;
            }
            return linha;
        }

        private double getCociente(double variavel, double pivo)
        {
            return variavel / pivo;
        }
    }
}
