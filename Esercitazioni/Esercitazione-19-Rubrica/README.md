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
