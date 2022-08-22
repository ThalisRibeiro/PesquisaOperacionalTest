using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POTesteMAUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;
using POTesteMAUI.Views;
using System.Collections.ObjectModel;

namespace POTesteMAUI.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainPageViewModel
    {
        public MainPageViewModel()
        {
            Possui3Produtos = false;
        }
        //parte da empresa
        [ObservableProperty]
        string nomeMP1;
        [ObservableProperty]
        string nomeMP2;
        [ObservableProperty]
        int qtdMP1;
        [ObservableProperty]
        int qtdMP2;
        [ObservableProperty]
        bool possui3Produtos;

        //parte dos produtos
        [ObservableProperty]
        string nomeP1;
        [ObservableProperty]
        double valorP1;
        [ObservableProperty]
        int p1MP1;
        [ObservableProperty]
        int p1MP2;

        [ObservableProperty]
        string nomeP2;
        [ObservableProperty]
        double valorP2;
        [ObservableProperty]
        int p2MP1;
        [ObservableProperty]
        int p2MP2;

        [ObservableProperty]
        string nomeP3;
        [ObservableProperty]
        double valorP3;
        [ObservableProperty]
        int p3MP1;
        [ObservableProperty]
        int p3MP2;

        // verificador da quantidade de produtos
        [RelayCommand]
        private void Possui3()
        {
            Possui3Produtos = true;
        }
        [RelayCommand]
        private void NaoPossui3()
        {
            Possui3Produtos = false;
        }

        // comando que inicia o algoritimo
        [RelayCommand]
        private async Task RodaAlgoritimo()
        {
            try
            {
                if (possui3Produtos == false)
                {
                    Empresa empresa = new(qtdMP1, qtdMP2,nomeMP1,nomeMP2);
                    Produto prod = new(nomeP1, valorP1, p1MP1,p1MP2);
                    Produto prod2 = new(nomeP2, valorP2, p2MP1, p2MP2);
                    ObservableCollection<Produto> produtos = new();
                    produtos.Add(prod);
                    produtos.Add(prod2);
                    Verificador verificador = new(ref empresa, ref prod, ref prod2);
                   await Shell.Current.GoToAsync($"{nameof(ResultPage)}", new Dictionary<string, object>
                    {
                        ["Empresa"] = empresa, ["Produtos"] = produtos,
                    }) ;
                }
                else if(possui3Produtos == true)
                {
                    Empresa empresa = new(qtdMP1, qtdMP2, nomeMP1, nomeMP2);
                    Produto prod = new(nomeP1, valorP1, p1MP1, p1MP2);
                    Produto prod2 = new(nomeP2, valorP2, p2MP1, p2MP2);
                    Produto prod3 = new(nomeP3, valorP3, p3MP1, p3MP2);
                    Verificador verificador = new(ref empresa, ref prod, ref prod2, ref prod3);
                    ObservableCollection<Produto> produtos = new();
                    produtos.Add(prod);
                    produtos.Add(prod2);
                    produtos.Add(prod3);
                    await Shell.Current.GoToAsync($"{nameof(ResultPage)}", new Dictionary<string, object>
                    {
                        ["Empresa"] = empresa,
                        ["Produtos"] = produtos,
                    });
                }
            }
            catch (Exception )
            {

                throw;
            }
        }

        //private bool verificado2Prod()
        //{
        //    if(nomeMP1==string.Empty||nomeMP2== string.Empty||nomeP1== string.Empty||nomeP2== string.Empty
        //        ||p1MP1<0||p1MP2<0||p2MP1<0||p2MP2<0)
        //        return false;

        //    return true;
        //}
    }
}
