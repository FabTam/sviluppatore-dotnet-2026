using Microsoft.AspNetCore.Identity;
using RubricaSemplice.Api.Dtos;
using RubricaSemplice.Api.Helpers;
using RubricaSemplice.Api.Models;

namespace RubricaSemplice.Api.Services;

public class AuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtHelper _jwtHelper;

    public AuthService(
        UserManager<ApplicationUser> userManager, // costruttore con classi di Identity per la gestione dell'user
        SignInManager<ApplicationUser> signInManager,
        JwtHelper jwtHelper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtHelper = jwtHelper;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto dto) // Task è una classe di sistema per le operazioni asincrone che accetta un tipo, in questo caso la classe IdentityResult.
    {
        // Cerchiamo se la mail esiste già
        ApplicationUser? existingUser = await _userManager.FindByEmailAsync(dto.Email);

        if (existingUser != null)
        {
            IdentityError error = new IdentityError();
            error.Description = "Email già registrata.";

            return IdentityResult.Failed(error);
        }

        // Creiamo l'utente nuovo
        ApplicationUser user = new ApplicationUser();
        user.UserName = dto.Email;
        user.Email = dto.Email;
        user.NomeCompleto = dto.NomeCompleto;
        user.PhoneNumber = dto.PhoneNumber;
        user.CreatedAt = DateTime.UtcNow;

        // Identity salva l'utente e crea l'hash sicuro della password
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        return result;
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        // Cerchiamo l'utente con la mail
        ApplicationUser? user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
        {
            return null;
        }

        // Controlliamo se la password è corretta
        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded)
        {
            return null;
        }

        string token = _jwtHelper.GenerateToken(user);

        AuthResponseDto response = new AuthResponseDto();
        response.Token = token;
        response.UserId = user.Id;
        response.Email = user.Email ?? string.Empty;
        response.NomeCompleto = user.NomeCompleto;

        return response;
    }
}