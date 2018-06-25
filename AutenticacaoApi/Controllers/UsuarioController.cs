using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticacaoApi.Model;
using AutenticacaoApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoApi.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {    
        [HttpGet]
        public IActionResult ValidaUsuario([FromQuery] LoginViewModel _viewModel)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var usuario = Repositorio.Repositorio.GetUsuarios()
                                .Where(u => u.Email == _viewModel.Email && u.Senha == _viewModel.Senha)
                                .Select(u => new {u.Token})
                                .FirstOrDefault();

                if(usuario == null)
                    return NotFound();
                
                return StatusCode(302, usuario);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult ValidaToken([FromQuery] string _token)
        {
            try
            {
                if(string.IsNullOrEmpty(_token))
                    return BadRequest("Necessário o token para validar o usuário!");

                var usuario = Repositorio.Repositorio.GetUsuarios()
                                .Where(u => u.Token == _token)
                                .FirstOrDefault();

                if(usuario == null)
                    return NotFound();

                return Ok("Sucesso");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}