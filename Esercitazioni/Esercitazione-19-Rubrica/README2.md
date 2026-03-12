# WEBAPI RUBRICA COMPLETA V1

- ApplicationUser che estende Identity User
- Tabella Interest collegata all'utente
- Authservice
- Interest service
- Controller semplici con operazioni crud

```bash
Rubrica.Api
|─── Controllers
     |─── AuthController.cs
     |─── InterestsController.cs
|─── Data
     |───  ApplicationDbContext.cs
|
|───  Dtos
|     |───  AuthResponseDto.cs
|     |───  InterestCreateDto.cs
|     |─── InterestDto.cs
|     |───  LoginDto.cs
|     |───  RegisterDto.cs
|
|
|───  Helpers
|     |───  ApplicationUser.cs
|     |───  Interest.cs
|
|
|───  Services
|    |───  AuthService.cs
|    |─── InterestService.cs
|
|─── Program.cs
|─── appsettings.json
```

# Modelli

User.cs

```C#
using MicroSoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_19_Rubrica.Dtos;

[Table("Users")] // decorator che permette di definire a quale tabella appartiene la tabella.
public class ApplicationUser : IdentityUser
{
    // IdentityUser ha già: Id, UserName, Email, PasswordHas, PhoneNumber ecc

    [Required]
    [StringLength(100)]
    public string NomeCompleto {get; set;} = string.Empty;

    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

    // un utente può avere molti interessi

    public List<Interest> Interest {get;set;} = new List<Interest>();
}
```


Interest.cs
Rappresenta un oggetto dell'utente con un nome e un collegamento all'utente a cui appartiene. Viene mappato alla tabella interests nel database e ha una realzione molti a uno con ApplicationUser.
```C#
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_19_Rubrica.Dtos;

[Table("Interests")]
public class Interest
{
    public int Id {get;set;}

    [Required]
    [StringLength(100)]
    public string Nome {get;set;} = string.Empty;

    // Con identity l'id utente è string
    [Required]
    public string UserId {get;set;} = string.Empty;

    // collegamento all'utente
    [ForeignKey("UserId")]
    public ApplicationUser? User {get;set;}
}

```
# DTO

RegisterDto.cs

Serve per fornire i dati necessari alla registrazione di un nuovo utente. Viene usato come input per l'endpoint di registrazione nell'AuthController.

```C#

using System.ComponentModel.DataAnnotations;

namespace  Esercitazione_19_Rubrica.Dtos;

public class RegisterDto
{
    [Required]
    [EmailAdress]
    public string Email {get; set;} = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password {get;set;} = string.Empty;

    [Required]
    [StringLegnght(100)]
    public string NomeCompleto {get; set;} = string.Empty;

    public string? PhoneNumber {get; set;}
}
```

LoginDto.cs

Serve per fornire i dati necessari per il login nell'AuthController

```C#

using System.ComponentModel.DataAnnotations;

namespace  Esercitazione_19_Rubrica.Dtos;

public class LoginDto
{
    [Required]
    [EmailAdress]
    public string Email {get; set;} = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password {get;set;} = string.Empty;

}
```

AuthResponseDto.cs

Serve per restituire i dati di risposta dopo una registrazione o un login riusciti. Viene usato come output per gli endpoind di registrazione e login nell'AuthController

```C#

using System.ComponentModel.DataAnnotations;

namespace  Esercitazione_19_Rubrica.Dtos;

public class AuthResponseDto
{
    public string Token {get; set;}        = string.Empty;
    public string UserId {get; set;}       = string.Empty;
    public string Email {get; set;}        = string.Empty;
    public string NomeCompleto {get; set;} = string.Empty;

}
```

InterestCreateDto.cs

```C#

using System.ComponentModel.DataAnnotations;

namespace  Esercitazione_19_Rubrica.Dtos;

public class InterestCreateDto
{
 [Required]
 [StringLength(100)]
 public string Nome {get;set;} = string.Empty;
}
```

InterestDto.cs

```C#

using System.ComponentModel.DataAnnotations;

namespace  Esercitazione_19_Rubrica.Dtos;

public class InterestDto
{
 public int Id {get;set;}
 public string Nome {get;set;} = string.Empty;
}
```

#  DbContext
---
Il DBContext è la classe principale di Entity Framework che gestisce la connessione dal database e le operazioni CRUD che vengono eseguite sulle entità dai services dell'applicazione.

## Creazione DbContext:

creare un file ApplicationDbContext.cs in /Data:

```C#

public class ApplicationDbContext : DbContext
{
    // costruttore che accetta le opzioni di configurazione di DbContext
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // qui non serve aggiungere niente, il costruttore base si occupa di configurare il DbContext con le opzioni fornite in Program.cs

    }

    // DbSet per la tabella Interessi
    public DbSet<Interest> Interests {get;set;}

}
```

# Helpers

JwtHelper.cs

```C#
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Esercitazione_19_Rubrica.Models;

namespace Esercitazione_19_Rubrica;

public class JwtHelper
{
  private readonly IConfiguration _configuration;
  public JwtHelper(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public string GenerateToken(ApplicationUser user)
  {
    // leggiamo i dati dal file appsettings.sjson

    string? key = _configuration["Jwt:Key"];
    string? issuer = _configuration["Jwt:Issuer"];
    string? audience = _configuration["Jwt:audience"];

    if((string.IsNullOrEmpty(key)) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
    {
        throw new Exception("Configurazione JWT mancante.");
    }


    // dentro il token mettiamo alcune informazioni utili
    Claim[] claims = new Claim[]
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName ?? ""),
        new Claim(ClaimTypes.Email, user.Email ?? "")

    };
    
    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    SigningCredentials credentials   = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    JwtSecurityToken token = new JwtSecurityToken(
        issuer   : issuer,
        audience : audience,
        claims   : claims,
        expires : DateTime.UtcNow.AddHours(1),
        signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
```

# Services

AuthService.cs
Gestisce la logica di registrazione e login degli utenti, utilizzando UserManager e SignInManager di Identity per interagire
con il database degli utenti e JwtHelper per generare i token JWT.

```C#
using Microsoft.AspNetCore.Identity;
using Esercitazione_19_Rubrica.Dtos;
using Esercitazione_19_Rubrica.Helpers;
using Esercitazione_19_Rubrica.Models;

namespace Esercitazione_19_Rubrica.Services;

using Microsoft.AspNetCore.Identity;
using Esercitazione_19_Rubrica.Dtos;
using Esercitazione_19_Rubrica.Helpers;
using Esercitazione_19_Rubrica.Models;

namespace Esercitazione_19_Rubrica.Services;

public class AuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtHelper _jwtHelper;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtHelper jwtHelper)
    {
        _userManager   = userManager;
        _signInManager = signInManager;
        _jwtHelper     = jwtHelper;
    }

    /*questo è un metodo asincrono che restituisce un IdentityResult, che indica se la registrazione è riuscita o no, e contiene eventuali errori eun metodo asicrono che è un metodo che può essere
     eseguito in modo non bloccante cioè puo fare operazioni che richiedono tempo senza bloccare il thread principale dell'applicazione
    */

    public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
    {
        // controlliamo se esiste già un utente con questa email (await fa restare in attesa il thread finchè l'operazione non è completa)
        ApplicationUser? existingUser = await _userManager.FindByEmailAsync(dto.Email);

        if(existingUser != null)
        {
            IdentityError error = new IdentityError();
            error.Description = "Email già registrata.";

            List<IdentityError> errors = new List<IdentityError>();
            errors.Add(error);
        }

        // creiamo il nuovo utente
        ApplicationUser user = new ApplicationUser();
        user.UserName     = dto.Email; // usiamo la mail anche come username
        user.Email        = dto.Email;
        user.NomeCompleto = dto.NomeCompleto;
        user.PhoneNumber = dto.PhoneNumber;
        user.CreatedAt    = DateTime.UtcNow;

        // Identity salva l'utente e crea l'has sicuro della password
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        return result;
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        // cerchiamo l'utente per email
        ApplicationUser? user = await _userManager.FindByEmailAsync(dto.Email);

        if(user == null)
        { 
            return null;
        }

        // controlliamo se la paswword è giusta
        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        
        if(!result.Succeeded)
        {
            return null;
        }

        // se tutto va bene creiamo il token
        string token = _jwtHelper.GenerateToken(user);

        AuthResponseDto response = new AuthResponseDto();
        response.Token        = token;
        response.UserId       = user.Id;
        response.Email        = user.Email ?? "";
        response.NomeCompleto = user.NomeCompleto;
        return response;
    }
}
```