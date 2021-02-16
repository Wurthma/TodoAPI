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
	- `dotnet add package MediatR`
	- `dotnet add package MediatR.Extensions.Microsoft.DependencyInjection`

- Rgistre o MediatR no **Startup.cs**:
```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.AddMediatR(Assembly.GetExecutingAssembly());

	// ...
}
```

### Repository Pattern

De forma resumida, aplicamos o repository pattern no projeto deixando o Domain o mais puro possível. OU seja, ele não depende da implementação mas da abstração (baixo acoplamento).

### Entity Framework Core 5

**VS Code**
Antes de realizar um migration no projeto de **Infra** verifique a versão atual do EF Tool, deve estar com a mesma versão do EF Core utilizado no projeto.

- Para verificar a versão execute: `dotnet ef`
- Para remover a versão atual instalada, execute: `dotnet tool uninstall --global dotnet-ef`
- Para instalar a versão mais recente, execute: `dotnet tool install --global dotnet-ef`
- Para executar um migration, execute: `dotnet ef migrations add NomeDaMinhaMigration --startup-project ..\Todo.Domain.Api\`
- Para atualizar o DB, execute: `dotnet ef database update --startup-project ..\Todo.Domain.Api\`

### Autenticação JWT Bearer

- `Microsoft.AspNetCore.Authentication.JwtBearer`
- Uso de Secrets para armazenar dados sensíveis referente ao Firebase para autenticação com google (https://docs.microsoft.com/pt-br/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)