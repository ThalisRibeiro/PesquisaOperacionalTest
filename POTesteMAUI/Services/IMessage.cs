using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POTesteMAUI.Services

{
    public interface IMessage
    {
        Task MostraMensagemErro(string title, string mensagem);
    }
}
