# TodoAPI

Dotnet API com uso de CQRS, MediatR, EF, DDD, Testes unitários, etc

# Exemplos importantes:

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