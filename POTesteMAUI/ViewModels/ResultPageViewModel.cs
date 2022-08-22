using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POTesteMAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POTesteMAUI.ViewModels
{
    [QueryProperty(nameof(Produtos), nameof(Produtos))]
    [QueryProperty(nameof(Empresa), nameof(Empresa))]
    [INotifyPropertyChanged]
    public partial class ResultPageViewModel
    {
        [ObservableProperty]
        ObservableCollection<Produto> produtos;
        [ObservableProperty]
        Empresa empresa;
        [ObservableProperty]
        double lucroTotal;

        public ResultPageViewModel()
        {
           
        }

        [RelayCommand]
        void CalculcaLucros()
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                LucroTotal += produtos[i].Lucro;
            }
        }
    }
}
