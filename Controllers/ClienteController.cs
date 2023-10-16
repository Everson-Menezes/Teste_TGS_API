using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Teste_TGS.Interfaces;
using Teste_TGS.Models;

namespace Teste_TGS.Controllers;

[ApiController]
[Route("api/cliente")]
public class ClienteController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(ILogger<ClienteController> logger, IClienteRepository clienteRepository)
    {
        _logger = logger;
        _clienteRepository = clienteRepository;
    }

    [HttpGet, ActionName("get")]
    public IActionResult Get()
    {
        var clientes = _clienteRepository.GetAllClientes();
        if (clientes.Count() == 0)
        {
            return NoContent();
        }

        return Json(clientes);
    }

    [HttpPost("create"), ActionName("create")]
    public IActionResult Create(Cliente cliente)
    {
        _clienteRepository.CreateCliente(cliente);
        return StatusCode(201);//trocar para created
    }
    [HttpGet("getById/{id}"), ActionName("getById")]
    public IActionResult GetById(int id)
    {

        if (id == 0)
        {
            return BadRequest();
        }

        var cliente = _clienteRepository.GetClienteById(id);

        if (cliente == null)
        {
            return NotFound();
        }
        cliente.Logradouros = new List<Logradouro>();
        var logradouros = _clienteRepository.GetAllLogradouros(cliente.Id);
        foreach (var item in logradouros)
        {
            Logradouro logradouroViewModel = new Logradouro
            {
                Id = item.Id,
                Rua = item.Rua,
                Bairro = item.Bairro,
                Cidade = item.Cidade,
                Estado = item.Estado,
                Pais = item.Pais,
                Cep = item.Cep,
                ClienteId = item.ClienteId
            };
            cliente.Logradouros.Add(logradouroViewModel);
        }


        return Json(cliente);
    }

    [HttpPut("edit"), ActionName("edit")]
    public IActionResult Edit(Cliente cliente)
    {

        if (ModelState.IsValid)
        {
            _clienteRepository.UpdateCliente(cliente);
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
        _clienteRepository.DeleteCliente(id);
        return Accepted();//retorna 202
    }
}