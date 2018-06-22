using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutenticacaoApi.Model;
using AutenticacaoApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacaoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {    
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
    }
}