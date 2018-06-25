using System;
using System.ComponentModel.DataAnnotations;

namespace AutenticacaoApi.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}