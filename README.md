# TodoAPI

Dotnet API com uso de CQRS, MediatR, EF, DDD, Testes unitários, etc

## Estrutura do projeto
- Domain
- Api (Application)
- Infra
- Tests

# Exemplos importantes:

### CQRS e MediatR

Basicamente temos dois componentes principais chamados de Request e Handler, que implementamos através das interfaces `IRequest` e `IRequestHandler<TRequest>` respectivamente.

- Request (ou Command) → mensagem que será processada.
- Handler → responsável por processar determinada(s) mensagen(s).

### Configurando o MediatR

- Para utilizar o MediatR no dotnet core ou superior é necessário instalar os seguintes pacotes:
	`dotnet add package MediatR`
	`dotnet add package MediatR.Extensions.Microsoft.DependencyInjection`

- No registre o MediatR no **Startup.cs**:
```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.AddMediatR(Assembly.GetExecutingAssembly());

	// ...
}
```

### Repository Pattern

De forma resumida, aplicamos o repository pattern no projeto deixando o Domain o mais puro possível. OU seja, ele não depende da implementação mas da abstração (baixo acoplamento).