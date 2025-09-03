using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroi.Application.DTOs;
using SuperHeroi.Application.Exceptions;
using SuperHeroi.Application.Interfaces;

namespace SuperHeroi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperPoderesController : ControllerBase
    {
        private readonly ISuperPoderesService _service;
        public SuperPoderesController(ISuperPoderesService service) => _service = service; 

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodosSuperPoderes()
        {
            try
            {
                var poderes = await _service.ObterTodosSuperPoderes();
                if (poderes == null)
                {
                    return Ok("Não há nenhum poder registrado.");
                }
                return Ok(poderes);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro interno no servidor" });
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegistrarSuperPoder(SuperPoderesDTO superPoderesDTO)
        {
            try
            {
                var registrarPoder = await _service.RegistrarSuperPoder(superPoderesDTO);
                return Ok(registrarPoder);
            }
            catch (AlreadyExistsException ex)
            {
                return BadRequest(new { message = ex });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno no servidor" });
            }
        }
    }
}
