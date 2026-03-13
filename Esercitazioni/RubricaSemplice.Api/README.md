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

ApplicationUser.cs
Estende IdentityUser, che è la classe base di Identity per rappresentare un utente. Aggiungiamo alcune proprietà personalizzate. Viene mappata alla tabella Users e ha una relazione una a molti
con la tabella interests.
```C#
using MicroSoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rubrica.Api.Dtos;

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

namespace Rubrica.Api.Dtos;

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

namespace  Rubrica.Api.Dtos;

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

namespace  Rubrica.Api.Dtos;

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

namespace  Rubrica.Api.Dtos;

public class AuthResponseDto
{
    public string Token {get; set;}        = string.Empty;
    public string UserId {get; set;}       = string.Empty;
    public string Email {get; set;}        = string.Empty;
    public string NomeCompleto {get; set;} = string.Empty;

}
```

InterestCreateDto.cs

Serve per fornire i dati necessari alla creazione o aggiornamento di un interesse. Viene usato come input per gli endpoint di creazione a aggiornamento degli interessi nell'InterestsController
```C#

using System.ComponentModel.DataAnnotations;

namespace  Rubrica.Api.Dtos;

public class InterestCreateDto
{
 [Required]
 [StringLength(100)]
 public string Nome {get;set;} = string.Empty;
}
```

InterestDto.cs
Serve per restituire i dati di un interesse. Contiene l'id e il nome dell'interesse. Viene usato come output per gli endpoint di lettura degli interessi nell'InterestsController.
```C#

using System.ComponentModel.DataAnnotations;

namespace  Rubrica.Api.Dtos;

public class InterestDto
{
 public int Id {get;set;}
 public string Nome {get;set;} = string.Empty;
}
```

#  DbContext
---
Il DBContext è la classe principale di Entity Framework che gestisce la connessione dal database e le operazioni CRUD che vengono eseguite sulle entità dai services dell'applicazione.
In questo caso ApplicationDbContext estende IdentityUsserContext per integrare Identity con il nostro modello di utente personalizzato e aggiunge un DbSet per la tabella interessi.

## Creazione DbContext:

creare un file ApplicationDbContext.cs in /Data:

```C#
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rubrica.Api.Models;

public class ApplicationDbContext : IdentityUserContext<ApplicationUser>
{
    // costruttore che accetta le opzioni di configurazione di DbContext
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
    {
 
    
    }
    // DbSet per la tabella Interessi
    public DbSet<Interest> Interests {get;set;}

}
```

# Helpers

JwtHelper.cs

JwtHelper è una classe di utilità che si occupa di generare token JWT per l'autenticazione degli utenti. Legge la chiave segreta, l'emittente e chi lo sta ricevendo dal file di configurazione appsettings.json e crea un token JWT che include informazioni dell'utente come ID, Username ecc. Il token viene firmato con HMAC SHA256 per garantire la sicurezza.

Il token viene generato automaticamente quando viene effettuato il login, e poi viene restituito al client Angular che lo userà per autenticarsi nelle richieste successive.
```C#
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Rubrica.Api.Models;

namespace Rubrica.Api;

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
using Rubrica.Api.Dtos;
using Rubrica.Api.Helpers;
using Rubrica.Api.Models;

namespace Rubrica.Api.Services;

using Microsoft.AspNetCore.Identity;
using Rubrica.Api.Dtos;
using Rubrica.Api.Helpers;
using Rubrica.Api.Models;

namespace Rubrica.Api.Services;

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

# Services

InterestService.cs
InterestService gestisce la logica di business per le operazioni CRUD sugli interessi degli utenti. Utilizza ApplicationDBContext per interagire con il database e implemeta
metodi asincroni per ottenere,creare aggiornare e cancellare interessi, assicurandosi che ogni operazione sia autorizzata solo per l'utente a cui appartiene l'interesse.

```C#
using Rubrica.Api.Data;
using Rubrica.Api.Dtos;
using Rubrica.Api.Models;

namespace Rubrica.Api.Services;

public class InterestService
{
    private readonly ApplicationDbContext _context;

    public InterestService(ApplicationDbContext context)
    {
         _context = context;
    }

    public async Task<List<InterestDto>> GetAllByUserIdAsync(string userId)
    {
        List<InterestDto> result = new List<InterestDto>();
        //prendiamo tutti gli interessi dal database
        List<Interest> allInterests = _context.Interests.ToList();

        //filtriamo a mano solo quelli dell'utente loggato
        for(int i = 0; i < allInterests.Count; i++)
        {
            Interest currentInterest = allInterests[i];

            if(currentInterest.UserId == userId)
            {
                InterestDto dto = new InterestDto();
                dto.Id          = currentInterest.Id;
                dto.Nome        = currentInterest.Nome;

                result.Add(dto);
            }
        }
        return await Task.FromResult(result);
    }

    public async Task<InterestDto?> GetByIdAsync (int id, string userId)
    {
        Interest? interest = await _context.Interests.FindAsync(id);

        if(interest == null)
        {
            return null;
        }

        // controlliamo che l'interesse appartenga all'utente giusto
        if(interest.UserId != userId)
        {
            return null;
        }

        InterestDto dto = new InterestDto();
        dto.Id   = interest.Id;
        dto.Nome = interest.Nome;
        
        return dto;

    }

    public async Task<InterestDto?> CreateAsync(InterestCreateDto dto, string UserId)
    {
        // Controllo semplice per evitare doppioni

        List<Interest> allInterests = _context.Interests.ToList();

        for (int i = 0; i < allInterests.Count; i++)
        {

            Interest currentInterest = allInterests[i];
            if(currentInterest.UserId == UserId && currentInterest.Nome == dto.Nome)
            {
                return null;
            }
        }
    
       Interest interest = new Interest();
       interest.Nome = dto.Nome;
       interest.UserId = UserId;

       _context.Interests.Add(interest);
       await _context.SaveChangesAsync();

       InterestDto result = new InterestDto();
       result.Id = interest.Id;
       result.Nome = interest.Nome;

       return result;
    }

    public async Task<InterestDto?> UpdateAsync(int id, InterestCreateDto dto, string userid)
    {
        Interest? interest = await _context.Interests.FindAsync(id);

        if(interest == null)
        {
            return null;
        }

        if(interest.UserId != null)
        {
            return null;
        }

        interest.Nome = dto.Nome;

        await _context.SaveChangesAsync();

        InterestDto result = new InterestDto();
        result.Id = interest.Id;
        result.Nome = interest.Nome;

        return result;
    }

    public async Task<bool> DeleteAsync (int id, string userId)
    {
        Interest? interest = await _context.Interests.FindAsync(id);

        if(interest == null)
        {
            return false;
        }

        if(interest.UserId != userId)
        {
            return false;
        }

        _context.Interests.Remove(interest);

        await _context.SaveChangesAsync();

        return true;
    }

}
```

# Controllers

AuthController

In questa applicazione i controller gesticono le richieste HTTP e restituiscono risposte. AuthController si occupa di gestire le operazioni di registrazione e login degli utenti,
utilizzando AuthService per eseguire la logica di business e restituendo i risultati al client Angular.

```C#

using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Services;

namespace Rubrica.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);

        if(!result.Succeeded)
        {
            List<string> errors = new List<string>();
            foreach(var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            
            return BadRequest(errors);
        }

        return Ok( new { message = "Registrazione completata"});
    }

    [HttpPost("login")]
    public async Task <IActionResult> login([FromBody] LoginDto dto)
    {
        AuthResponseDto? response = await _authService.LoginAsync(dto);

        if(response == null)
        {
            return Unauthorized ( new { message = "Email o password non validi."});
        }

        return Ok(response);
    }
}

```
InterestController.cs

Gestisce le operazioni CRUD sugli interessi degli utenti. Utilizza InterestService per eseguire la logica di business e restiruisce i risultati al client Angular. Tutti gli endpoint sono
protetti con l'attributo [Authorize], quindi è necessario essere autenticati con un token JWT valido per accedervi.

```C#

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rubrica.Api.Dtos;
using Rubrica.Api.Services;

namespace Rubrica.Api.Controllers;

[ApiController]
[Route("api/[controler]")]
[Authorize]

public class InterestsController : ControllerBase
{
    private readonly InterestService _interestService;

    public InterestsController(InterestService interestService)
    {

        _interestService = interestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        string userId = GetUserIdFromToken();

        List<InterestDto> interests = await _interestService.GetAllByUserIdAsync(userId);

        return Ok(interests);
    }

    [HttpGet("{id}")]
    public async Task <IActionResult> GetById(int id)
    {
        string userId = GetUserIdFromToken();

        InterestDto? interest = await _interestService.GetByIdAsync(id, userId);

        if(interest == null)
        {
            return NotFound (new { message = "Interesse non trovato."});
        }

        return Ok(interest);
    }

    [HttpPost]
    public async Task <IActionResult> Create([FromBody] InterestCreateDto dto)
    {
        string userId = GetUserIdFromToken();

        InterestDto? result = await _interestService.CreateAsync(dto, userId);

        if(result == null)
        {
            return BadRequest( new { message = "Interesse già presente oppure non valido"});
        }

        return CreatedAtAction(nameof(GetById),new{ id = result.Id}, result);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update (int id, [FromBody] InterestCreateDto dto)
    {
        string userId = GetUserIdFromToken();

        InterestDto? result = await _interestService.UpdateAsync(id, dto, userId);
        if( result == null)
        {
            return NotFound(new {message = "Interesse non trovato"});
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> Delete (int id)
    {
        string userId = GetUserIdFromToken();

        bool deleted = await _interestService.DeleteAsync(id, userId);

        if(!deleted)
        {
            return NotFound(new {message = "Interesse non trovato."});
        }

        return NoContent();
    }

    private string GetUserIdFromToken()
    {

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if(string.IsNullOrEmpty(userId))
        {
            throw new Exception("UserId non trovato nel token");
        }

        return userId;
    }
}
```

# Program Cs

```C#
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rubrica.Api.Data;
using Rubrica.Api.Helpers;
using Rubrica.Api.Models;
using Rubrica.Api.Services;
using Rubrica.Api.Dtos;
using Rubrica.Api.Seed;

var builder = WebApplication.CreateBuilder(args);

// aggiunge i controller
builder.Services.AddControllers();

// Configurazione DbContext con SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurazione CORS per permettere al frontend Angular di accedere all'api
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

//Configura Identity per gli utenti

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    //Regole password semplice per fare pratica
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    
})
.AddSignInManager<SignInManager<ApplicationUser>>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

//configurazione JWT

string? jwtKey      = builder.Configuration["Jwt:Key"];
string? jwtIssuer   = builder.Configuration["Jwt:Issuer"];
string? jwtAudience = builder.Configuration["Jwt: Audience"];

if(string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
{
    throw new Exception("Configurazione JWT mancante in appsettings.json");
}

// Configurazione autenticazione JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>
{
  options.TokenValidationParameters = new TokenValidationParameters
 {
    // controlla che il token sia stato emesso dall'issuer corretto
    ValidateIssuer = true,

    // controlla che il token sia destinato all'audience corretta
    ValidateAudience = true,

    //controlla che il token non sia scaduto
    ValidateLifetime = true,

    //controlla la firma del Token
    ValidateIssuerSigningKey = true,

    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))

 };
});

//abilita l'autorizzazione con [Authorize]
builder.Services.AddAuthorization();

// Dependency Injection : registriamo  services e helper

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<InterestService>();
builder.Services.AddScoped<JwtHelper>();

var app = builder.Build();

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// applica automaticamente le migration all'avvio

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}


// Richiama il seed iniziale con alcuni utenti demo e i loro interessi. Se i dati esistono già non vengono duplicati.

await DataSeeder.SeedAsync(app.Services);
app.Run();

```

# Seed/DataSeeder.cs

DataSeeder è una classe statica che si occupa di popolare il database con dati iniziali per facilitare i test e lo sviluppo. il metodo SeedAsync crea alcuni utenti demo e interessi associati
a quegli utenti, ma prima controlla se esistono già per evitare duplicazioni. Viene chiamato all'avvio dell'applicazione dopo aver applicato le migrazioni al database.

```C#
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rubrica.Api.Data;
using Rubrica.Api.Models;

namespace Rubrica.Api.Seed;

public static class DataSeeder
{
    // questo metodo crea utenti e interessi iniziali. Se i dati esistono già, non li duplica.
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // creiamo il database se non esiste ancora

        await context.Database.EnsureCreatedAsync();

        // creiamo alcuni utenti demo
        ApplicationUser utente1 = await CreateUserIfNotExistsAsync(
            userManager,
            "utente1@gmail.com",
            "123456",
            "Utente uno",
            "3331234567");

            ApplicationUser utente2 = await CreateUserIfNotExistsAsync(
            userManager,
            "utente2@gmail.com",
            "123456",
            "utente due",
            "3332354567");

            ApplicationUser utente3 = await CreateUserIfNotExistsAsync(
            userManager,
            "untente3@gmail.com",
            "123456",
            "utente tre",
            "3331894567");

            // creiamo alcuni interessi per ogni utente

            await CreateInterestIfNotExistsAsync(context, utente1.Id, "Calcio");
            await CreateInterestIfNotExistsAsync(context, utente1.Id, "Csharp");
            await CreateInterestIfNotExistsAsync(context, utente1.Id, "Cinema");

            await CreateInterestIfNotExistsAsync(context, utente2.Id, "Libri");
            await CreateInterestIfNotExistsAsync(context, utente2.Id, "Angular");
            await CreateInterestIfNotExistsAsync(context, utente2.Id, "Musica");

            await CreateInterestIfNotExistsAsync(context, utente3.Id, "Nuoto");
            await CreateInterestIfNotExistsAsync(context, utente3.Id, "Viaggi");
            await CreateInterestIfNotExistsAsync(context, utente3.Id, "Cucina");

        
    }

    private static async Task<ApplicationUser> CreateUserIfNotExistsAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string password,
        string nomeCompleto,
        string? phoneNumber)
    {
        // controlliamo se l'utente esiste già tramite email
        ApplicationUser? existingUser = await userManager.FindByEmailAsync(email);

        if( existingUser != null)
        {
            return existingUser;
        }

        ApplicationUser user = new ApplicationUser();
        user.UserName = email;
        user.Email = email;
        user.NomeCompleto = nomeCompleto;
        user.PhoneNumber = phoneNumber;
        user.CreatedAt = DateTime.UtcNow;

    

    IdentityResult result = await userManager.CreateAsync(user, password);

    if(!result.Succeeded)
    {
      List<string> errors = new List<string>();

      foreach( IdentityError error in result.Errors)
      {
        errors.Add(error.Description);
      }
      string message = string.Join("|", errors);
      throw new Exception($"Errore durante la creazione dell'utente {email} : {message}");
    }
     return user;
  }

   private static async Task CreateInterestIfNotExistsAsync(
    ApplicationDbContext context,
    string userId,
    string nome)
    {
      //leggiamo tutti gli interessi e controlliamo a mano
      // see questo interesse esiste già per quell'utente.

      List<Interest> interests = await context.Interests.ToListAsync();

      for(int i = 0; i < interests.Count; i++)
      {
        Interest currentInterest = interests[i];

        bool sameUser = currentInterest.UserId == userId;
        bool sameName = string.Equals(currentInterest.Nome, nome, StringComparison.OrdinalIgnoreCase);

        if(sameUser && sameName)
        {
            return;
        }
      }

      Interest interest = new Interest();
      interest.UserId = userId;
      interest.Nome = nome;

      context.Interests.Add(interest);
      await context.SaveChangesAsync();
    }
   
}

```
# appsettings.json

```json

{
    "ConnectionStrings" :{
        "DefaultConnection": "Data Source=rubrica.db"
    },
    "Jwt":{
        "Key": "questa-e-una-chiave-molto-lunga-di-almeno-32-caratteri",
        "Issuer": "RubricaApi",
        "Audience": "RubricaAngular"
    },

    "Logging" :{
        "LogLevel":{
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}
```

# Pacchetti da installare
```bash
dotnet tool install --global dotnet-ef ( basta installare una volta per sistema)

// Entity Framework Core e SQLite
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

// strumenti per migrazione
dotnet add package Microsoft.EntityFrameworkCore.Design


// JWT e autenticazione
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt

