using System;
using System.Collections.Generic;
using System.Linq;
using AutenticacaoApi.Model;

namespace AutenticacaoApi.Repositorio
{
    public static class Repositorio 
    {
        public static IEnumerable<Usuario> GetUsuarios()
        {
            List<Usuario> _listUsuario = new List<Usuario>                
                { 
                    new Usuario 
                    {
                        Id = 1,
                        Nome = "Primeiro Nome",
                        Email = "primeiro@email.com.br",
                        Senha = "primeira",
                        Token = "primeirotoken1"
                    },

                    new Usuario 
                    {
                        Id = 2,
                        Nome = "Segundo Nome",
                        Email = "segundo@email.com.br",
                        Senha = "segundo",
                        Token = "segundotoken1"
                    },

                    new Usuario 
                    {
                        Id = 3,
                        Nome = "Terceiro Nome",
                        Email = "terceiro@email.com.br",
                        Senha = "terceiro",
                        Token = "terceirotoken1"
                    }
                };

            return _listUsuario;
        }
    }    
}