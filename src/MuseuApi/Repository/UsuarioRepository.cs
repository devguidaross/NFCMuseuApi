using System;
using System.Linq;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using MuseuApi.Models;

namespace MuseuApi.Repository
{
    public static class UsuarioRepository
    {
        public static ResponsePadrao Login(string aLogin, string aSenha)
        {
            try
            {
                var lUsuario = Startup.MuseuContext.Usuario.FirstOrDefault(u => u.Login == aLogin && u.Senha == aSenha);
            
                return lUsuario != null ? new ResponsePadrao()
                {
                    Sucesso = true,
                    Data = lUsuario,
                    Codigo = lUsuario.Id,
                    Mensagem = "Usuário logado!"
                }: new ResponsePadrao()
                {
                    Sucesso = false,
                    Mensagem = "Usuário ou senha incorretos!"
                };
            }
            catch (Exception e)
            {
                return new ResponsePadrao()
                {
                    Sucesso = false,
                    Mensagem = e.Message
                };
            }
        }
    }
}