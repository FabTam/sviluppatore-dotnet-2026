using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RubricaSemplice.Api.Dtos;
using RubricaSemplice.Api.Models;
using RubricaSemplice.Api.Services;

namespace RubricaSemplice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = UserRoles.Admin)]

public class AdminUsersController : ControllerBase
{
    private readonly UserRoleService _userRoleService;
    private readonly AuthService _authService;


    public AdminUsersController(UserRoleService userRoleService, AuthService authService)
    {
        _userRoleService = userRoleService;
        _authService = authService;
    }

    [HttpPut("change-role")]
    public async Task<IActionResult> ChangeRole([FromBody] ChangeUserRoleDto dto)
    {
        string? newRole = await _userRoleService.ChangeUserRoleAsync(dto);
        if (newRole == null)
        {
            return BadRequest(new { message = "utente o ruolo non valido." });
        }
        return Ok(new
        {
            message = "Ruolo aggiornato correttamente",
            email = dto.Email,
            role = newRole
        });
    }

    [HttpGet("listaUtenti")]
    public async Task<IActionResult> GetAllUsers()
    {
        List<UserProfileDto> users = await _authService.GetAllUsersAsync();
        
        string? utenteId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (utenteId == null)
        {
            return Unauthorized("Utente non autenticato.");
        }

        return Ok(users);
    }
}
