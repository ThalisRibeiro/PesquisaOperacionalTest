using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POTesteMAUI.Services
{
    public class Message : IMessage
    {
        public async Task MostraMensagemErro(string title ,string mensagem)
        {
            await App.Current.MainPage.DisplayAlert(title, mensagem, "OK");
        }
    }
}
