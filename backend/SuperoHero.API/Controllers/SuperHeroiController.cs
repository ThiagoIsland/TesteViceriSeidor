using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroi.Application.DTOs;
using SuperHeroi.Application.Exceptions;
using SuperHeroi.Application.Interfaces;
using SuperHeroi.Application.Services;
using SuperHeroi.Domain.Entities;

namespace SuperHeroi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SuperHeroiController : ControllerBase
    {
        private readonly ISuperHeroiService _service;
        public SuperHeroiController(ISuperHeroiService service) => _service = service;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterTodosSuperHerois()
        {
            try
            {
                var herois = await _service.ObterTodosHerois();
                if (herois == null)
                {
                    return Ok("Não há nenhum héroi registrado.");
                }
                return Ok(herois);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro interno no servidor" });
            }

        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterSuperHeroi(int id)
        {

            try
            {
                var heroi = await _service.ObterHeroiPeloId(id);
                return Ok(heroi);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { message = ex });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex });
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
        public async Task<IActionResult> RegistrarSuperHeroi(SuperHeroiDTO heroiDTO)
        {
            try
            {
                var criarHeroi = await _service.RegistrarSuperHeroi(heroiDTO);
                return Ok("Heroi registrado");
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
        [HttpPut("{id}")]
        public void AtualizarSuperHeroi(int id, SuperHeroiDTO heroiDTO)
        {

        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletarSuperHeroi(int id)
        {
            try
            {
                await _service.RemoverHeroi(id);
                return Ok("Herói deletado!");
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { message = ex });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro interno no servidor" });
            }
        }
    }
}
