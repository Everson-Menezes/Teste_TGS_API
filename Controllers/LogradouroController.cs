using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teste_TGS_API.Interfaces;
using Teste_TGS_API.Models;

namespace Teste_TGS.Controllers;

[Authorize]
[ApiController]
[Route("api/logradouro")]
public class LogradouroController : Controller
{
    private readonly ILogger<LogradouroController> _logger;
    private readonly ILogradouroRepository _logradouroRepository;

    public LogradouroController(ILogger<LogradouroController> logger, ILogradouroRepository logradouroRepository)
    {
        _logger = logger;
        _logradouroRepository = logradouroRepository;
    }
    [HttpGet("get/{id}/{clienteId}")]
    public IActionResult Get(int id, int clienteId)
    {
        var logradouro = _logradouroRepository.GetLogradouroById(id, clienteId);
        if (logradouro == null)
        {
            return NotFound();
        }
        return Json(logradouro);
    }

    [HttpPost("create"), ActionName("create")]
    public IActionResult Create(Logradouro logradouro)
    {
        if (ModelState.IsValid)
        {
            _logradouroRepository.CreateLogradouro(logradouro);
            return StatusCode(201);//trocar para created
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpPut("edit"), ActionName("edit")]
    public IActionResult Edit(Logradouro logradouro)
    {

        if (ModelState.IsValid)
        {
            _logradouroRepository.UpdateLogradouro(logradouro);
            return NoContent();// retorna 204
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
    [HttpDelete("delete/{id}"), ActionName("delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _logradouroRepository.DeleteLogradouro(id);
        return Accepted();//retorna 202
    }

}