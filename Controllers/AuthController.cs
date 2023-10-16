using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teste_TGS_API.Interfaces;
using Teste_TGS_API.Models;
using System.Security.Claims;


namespace Teste_TGS.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IJwtService _authService;

    public AuthController(ILogger<ClienteController> logger, IJwtService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpGet, ActionName("get")]
    public IActionResult Get()
    {

        return Json(_authService.GenerateToken());
    }
}