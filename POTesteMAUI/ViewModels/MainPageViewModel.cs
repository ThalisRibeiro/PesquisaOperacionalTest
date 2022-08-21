using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POTesteMAUI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace POTesteMAUI.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainPageViewModel
    {
        public MainPageViewModel()
        {
            Possui3Produtos = true;
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
    }
}
