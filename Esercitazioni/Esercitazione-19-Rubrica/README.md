# WEB API APP

L'archetipo web API è un progeto ASP.NET Core che esponde endopoin http per consentire a client frontend come Angular di interagire con i dati prodotti dal backend.
Il comando per creare un'applicazione Web Api è :

```bash
dotnet web api -n Rubrica.Api
```

## Struttura tipica di una Web API


```bash
Rubrica.Api
|─── Controllers
|─── Models
|─── Services
|─── Repositories
|─── Data
|─── Dtos
|─── Migrations
|─── Middleware
|─── Helpers
|─── Properties
|  └ LaunchSettings.json
|─── Program.cs
|─── appsetttings.json
```

## Cartelle principali:

- Controllers: contiene i controller che gestiscono le richieste HTTP e restituiscono risposte.
- Models: contiene le classi che rappresentano i dati e le entità del dominio.
- Services: contiene la logica di business e i servizi che interagiscono con i dati, cioè le operazioni CRUD e altre logiche complesse.
- Repositories: contengono
- Data: Contiene il contesto del database e le classi di accesso ai dati.
- Dtso: Contiene le classi Data Transfer Object, che sono altri modelli specifici per il trasferimento dei dati tra client e server, spesso usati per evitare di esporre direttamente le entità 
       del dominio.
- Migrations: Contiene le migrazione di Entity Framework per gestire le modifiche al database quando viene modificato un modello.
- Middleware : Contiene componenti middleware personalizzati per gestire richieste e risposte HTTP, ad esempio per la gestione degli errori o l'autenticazione.
- Helpers: Contiene classi di utilità e helper per operazioni comuni, come la gestione dei file, la validazione personalizzata, ecc.
- Properties: contiente file di configurazione specifici del progetto, come LaunchSettings.json che definisce le configurazioni di avvio per l'applicazione.
- Program.cs : il punto di ingresso dell'applicazione, dove viene configurato il pipeline di esecuzione e i servizi.
- appsettings.json: il file di configurazione principale dell'applicazione, dove vengono definiti parametri come stringhe di connessione al database, chiavi API e altre impostazioni.


## Controllers

I controllers sono classi che ereditano da ControllerBase e sono decorati con l'attributo [ApiController]. Ogni metodo  all'interno di un controller rappresenta un endpoint HTTP e viene decorato con attributi come:

- [HttpGet]
- [HttpPost]
- [HttpPut]
- [HttpDelete]

che indicano il tipo di richiesta da fare

``` c#
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok();
    }
}

```
Il controller riceve richieste tipo:

```
GET /api/users
```

Di solito le richieste vengono inoltrate attraverso comandi CURL o client HTTP come Postman, oppure da un frontend Angula che consuma l'API.

## Models

I modelli rappresentano le entià del dominio e sono mappati a tabelle del database.

Ad Esempio, un modello Contatto potrebbe essere:

```C#
public class Contatto
{
    public int Id {get; set;}
    public string Nome {get; set;}
    public int Cognome {get; set;}
    public List<ContattoInteresse> Interessi {get; set;}

}

```

Quando usiamo Entity Framework Core, diventano tabelle.

## DTOS (Data Transfer Objects)

Servono per non esporre direttamente i Models
Ad esempio, potremmo avere un ContattoDto che contiene solo alcune proprietà:

```C#
public class ContattoDto
{
    public int Id {get; set;}
    public string Nome {get; set;}
    public int Cognome {get; set;}
}
```
Utile per sicurezza e controllo dati.


## Services

Qui mettiamo la logica business, tipo le operazioni CRUD e altre logiche complesse.
Ad esempio un ContattoService potrebbe avere metodi come:

```C#
public class ContattoService
{
    public List<Contatto> GetAll()
    {
      
    }

    public Contatto GetById (int id)
    {

    }
}

```

Il service viene poi iniettato nel controller per essere usato negli endpoint.

## Repositories

Accesso ai dati/database.
Ad esempio, un ContattoRepository potrebbe usare Entity Framework per interagire con il database.

# Services

Qui mettiamo la logica business, tipo le operazioni CRUD e altre logiche complesse.
Ad esempio un ContattoService potrebbe avere metodi come:

```C#
public class ContattoRepository
{
    private readonly AppliCationDbcContext _context;

    public ContattoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Contatto> GetAll()
    {
        return _context.Contatti.ToList();
    }

}
```
separa database dalla logica.

## Data

Contiene il DbContext

Ad esempio, ApplicationDbContext potrebbe essere:

```C#
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set;}
}

```
IL DbContext è la classe principale di Entity Framework che gestisce la connessione al database e le operazioni CRUD che vengono eseguite sulle entità dai services dell'applicazione.

## Migrations

Le migrations vengono generate automaticamente da Entity Framework:

```bash
dotnet ef migrations add InitialCreate
donet ef database updata
```
gestiscono modifiche allo schema del database.

## Middleware

Per intercettare richieste globali:

- logging
- auth
- error handling

Ad esempio, un middleware per gestire le eccezioni globali:

```C#
public class ExceptionMiddleware
{

}
```
## Helpers

Funzioni utility.

Esempio:
- JWT generator
- Date formatter
- Hashing password

Nello specifico JWT sarà quello che si usa per autenticare i client Angular.

## Program cs

Qui si configura il pipeline di esecuzione e i servizi.

Ad esempio, per configurare Entity Frameworkd e i servizi:

```C#
var builder = WebApplication.CreateBuilder(args)

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaulConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
App.Run();
```

## Esempio pratico

Contatto
Richiesta:

```
POST /api/contatto/5/

```

Flusso generico delle informazioni:

- Controller riceve la richiesta
- Controller chiama ContattoService
- ContattoService chiama ContattoRepository
- ContattoRepository legge il db e restituisce i dati
- I dati vengono ritornati al Model e poi al Controller
- Controller restituisce la risposta HTTP al client Angular passando attraverso un DTO.
- response in JSON ad Angular.


# WEBAPI RUBRICA COMPLETA V1

- ApplicationUser che estende Identity User
- Tabella Interest collegata all'utente
- Authservice
- Interest service
- Controller semplici con operazioni crud


Rubrica.Api
|-- Controllers
     |--- AuthController.cs
     |--- InterestsController.cs
|-- Data
     |--- ApplicationDbContext.cs
|
|--- Dtos
|     |-- AuthResponseDto.cs
|     |-- InterestCreateDto.cs
|     |-- InterestDto.cs
|     |-- LoginDto.cs
|     |-- RegisterDto.cs
|
|
|--- Helpers
|     |--- ApplicationUser.cs
|     |---- Interest.cs
|
|
|--- Services
|    |--- AuthService.cs
|    |-- InterestService.cs
|
|--- Program.cs
|--- appsettings.json


La web api rubrica userà JWT per autenticare i client Angular e avrà:

# Modelli:
- un modello Contatto con proprietà come Id, Nome Completo, Telefono, stato attivo, una lista di competenze, una data di creazione.
- un modello User con Id, Username, PasswordHash, e Ruolo per gestire l'autenticazione e autorizzazione e il collegamento con i contatti.
- Data Annotations e Decorators per validazione e sicurezza.
---
# DTO
- un DTO ContattoDto con solo alcune proprietà per esporre i dati in modo sicuro.
- un DTO UserDto con solo alcune proprietà per esporre i dati in modo sicuro.
---
# Controller
- un controller ContattoController con endpoint CRUD per gestire i contatti.
- un controller UserController.
- un controller AuthController per gestire l'autenticazione e la generazione dei token JWT.
---
# Services
- Un servizio ContattoService che contiene la logica di business per i contatti.
- Un servizio UserService che contiene la logica di business per gli indirizzi.
- un servizio AuthService per la logica di autenticazione e gestione dei token JWT.
---
# Repository
- un repository ContattoRepository che interagisce con il database usando entity framework core.
- un repository UserRepository per gestire gli utenti e le credenziali di autenticazione.
- un repository AuthRepository per gestire la logica di autenticazione e validazione delle credenziali.
---
# Data
- un DbContext ApplicationDbContext che rappresenta il database e contiene un `DbSet<Contatto>` e un `Dbset<User>`.
- Configurazione in Program.cs per registrare i servizi, configurare Entity Framework, e abilitare l'autenticazione JWT.
---
# Middleware
- un middleware JwtMiddleware per intercettare le richieste e validare i token JWT, assicurando che solo utenti autenrticati possano accedere agli endpoint protetti
- un middlware di gestione degli errori per catturare le eccezioni globali e restituire risposte HTTP appropriate in caso di errori.
---
# Helpers
- un helper JwtHelper per generare e validare i token JWT
- un helper Password Helper per gestire l'hashing e la verifica della password.
---
# Migrations:
- Migrazioni per creare le tabelle Contatti e Users nel database usando Entity Framework Core.

# CREAZIONE PROGETTO E COMANDI

Creazione archetipo webapi 

```bash
dotnet new webapi -o Rubrica.Api
```
Installazione librerie
```bash
// Entity Framework Core e SQLite
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

// strumenti per migrazione
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design

// JWT e autenticazione
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.IdentityModel.Tokens
```
scarica il dll di sqlite dal sito e inserisci il percorso del file dll nelle variabili di sistema dentro PATH

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

    // DbSet per la tabella Contatti
    public DbSet<Contatto> Contatti {get;set;}
    public DbSet<User> Users {get;set;}

}
```
## Creazione Modelli

I modelli rappresentanto le enetità del dominio e sono mappati a tabelle del database. In questo caso abbiamo un modello Contatto e un modello User.

```C#

public class Contatto
{
  public int Id {get;set;}// chiave primaria
  [Required]
  [StringLength(100)]
  public string Nomecompleto {get;set;} = string.empty
  [Required]
  [StringLength(30)]
  public string Telefono {get;set;} = string.Empty
  public bool IsActive {get;set;}
  public List<string> Competenze {get;set;} = new();
  public DateTime CreatedAt {get;set;} = DateTime.UtcNow;

  // foreign key: ogni contatto appartiene ad un utente
 public int UserId{get;set;}

 // proprietà di navigazione: EF Core usa questa proprietà
 // per collegare il contatto al suo utente

 public User User{get;set;} = null!;
}

public class User
{

 [Required]
  [StringLength(50)]
  public string Username {get;set;} = string.Empty;
  [Required]
  public string PasswordHash {get;set;} = string.Empty;
  [Required]
  [StringLength(20)]
  public string Ruolo {get;set;} = "User";

  // un utente può avere molti contatti

 public List<Contatto> Contatti{get;set;} = new();

}

```

## Creazione DTOS

I DTOS servono per non esporre direttamente i Models e per controllare quali dati vengono trasferiti tra client e server.

File ContattoDto.cs in/Dtos

```C#
public class ContattoDto
{ 
    // Dto di risposta: è quello che rimandiamo al frontend
    public int Id {get;set;}
    public string NomeCompleto {get;set;} = string.Empty;
    public string Telefono {get;set;} = string.Empty;
    public bool IsActive {get;set;} 
    public List<string> Competenze {get;set;} = new();
    public DateTime CreatedAt {get;set;}
}

public class UserDto
{  
    public int Id {get;set;}
    public string Username {get;set;} = string.Empty;
    public string Ruolo {get;set;} = string.Empty;
}
```
IMPORTANTE : Gli altri DTO che servono dobbiamo ancora farli e saranno:
- ContattoCreateDto.cs (le competenze possono essere vuote ma non null)
- ContattoUpdateDto.cs
- RegisterUserDto.cs (Se non passsiamo il ruolo diventa User di default)
- LoginDto.cs
- AuthResponseDto.cs (DTO che torniamo al frontend dopo il login)
---
# CONFIGURAZIONE IN PROGRAM CS

Il Program.cs è il punto di ingresso dell'applicazione, dove viene configurato il pipeline di esecuzione e i servizi. Qui configuriamo Entity Framework, JWT, e registriamo i servizi e repository.

OPZIONALE : Possiamo configurare un seed(meglio se su un file separato) dove viene preso l'admin di default e tre utenti, uno per ogni ruolo
Nel Program.cs:

```C#
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rubrica.Api.Data;
using Rubrica.Api.Helpers;
using Rubrica.Api.Middleware;
using Rubrica.Api.Models;
using Rubrica.Api.Repositories;
using Rubrica.Api.Services;
using Rubrica.Api.Dtos;

var builder = WebApplication.CreateBuilder(args)

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

//leggiamo la chiave JWT da appsettings
var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new Exception("Jwt: Key mancante in appsettings.json");

// Configurazione autenticazione JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>
{
  options.ToknValidationParameters = new TokenValidationParameters
 {
    // controlla che il token sia stato emesso dall'issuer corretto
    ValidateIssuer = true,

    // controlla che il token sia destinato all'audience corretta
    ValidateAudience = true,

    //controlla che il token non sia scaduto
    ValidateeLifetime = true,

    //controlla la firma del Token
    ValidateIssuerSigningKey = true,

    ValidIssuer = builder.Configuration["Jwt:Issuer"]
    ValidAudience = builder.Configuration["Jwt:Audience"]
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtkey))

 };
});

//abilita l'autorizzazione con [Authorize]
builder.Services.AddAuthorization();

// Dependency Injection : registriamo repository, services e helper

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ContattoRepository>();
builder.Service.AddScoped<userService>();
