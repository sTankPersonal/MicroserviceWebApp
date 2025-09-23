# .NET Microservices: Architecture for Containerized .NET Applications

This repository implements a modular, layered microservices architecture **Template** project targeting .NET 9 and containerized deployment.

## Disclaimer

This is a template and starting point for building microservices with C# .NET. It is not a complete production-ready solution. It must be adapted and extended to fit specific domain requirements, and requires security, scalability, monitoring, and deployment implementation.  
This template was written by Sean Tank following the book ".NET Microservices: Architecture for Containerized .NET Applications" by Cesar de la Torre, Bill Wagner, and Mike Rousos. (https://learn.microsoft.com/en-us/dotnet/architecture/microservices/).  
I am not affiliated with Microsoft or the authors.  
I am not making any money nor using this in any business capacity because this is simply a fun personal learning exercise for me.  
This project is not tested for any security vulnerabilities (outside of hidden user secrets) or performance issues; as such, it should not be used in production without thorough review and testing.  
Please do not fork/use/distribute this code without written permission from Sean Tank. Any potential use of this project is provided "as is" without warranty of any kind; nor should any issues be held against Sean Tank in any way.  
Feel free to open issues or pull requests if you find any problems or have suggestions for improvement. I gratefully appreciate any feedback.   

Thank you!  
Sean

---

## Project Structure

Template App/
- src/
  - Services/
    - Recipes/                            <-- Service A (Recipe Tracker)
      - Recipes.API/                       <-- Presentation layer
        - Controllers/
        - DTOs/
        - Filters/
        - Program.cs / Startup.cs
      - Recipes.Application/               <-- Application layer (use cases)
        - Commands/
        - Queries/
        - Services/
        - Interfaces/
        - DTOs/
      - Recipes.Domain/                    <-- Domain layer (core business logic)
        - Entities/
        - ValueObjects/
        - Aggregates/
        - Events/
        - Exceptions/
        - Interfaces/
      - Recipes.Infrastructure/            <-- Infra & data access
        - Persistence/
        - Repositories/
        - Services/
        - Migrations/
      - Recipes.Tests/
        - Domain.Tests/
        - Application.Tests/
        - API.Tests/
    - Chores/                              <-- Service B (future)
  - BuildingBlocks/
    - SharedKernel/                       <-- BaseEntity, ValueObject, Result<T>, IRepository, PagedQuery/PagedResult
    - EventBus/                           <-- IntegrationEvent, IIntegrationEventHandler, IEventBus, registration extensions
    - CrossCutting/                       <-- Logging, caching, middleware abstractions
  - Clients/
    - WebApp/
- tests/
- deploy/
- README.md

---

## Building blocks — templates and abstract classes

The BuildingBlocks folder provides the reusable base types across services. Use these rather than duplicating common abstractions.

SharedKernel (what to use)
- BaseEntity<TId> — base entity (Id, domain events, equality helpers). Extend by creating domain entities that inherit BaseEntity.
- ValueObject — (if present) base for immutable value objects.
- IRepository<T> — generic repository contract used by Domain interfaces and implemented in Infrastructure.
- PagedQuery / PagedResult<T> and Result<T> — common helpers for paging and operation results.
- IDomainService — marker for cross-aggregate domain services.

EventBus (what to use)
- IntegrationEvent — base for cross-service events.
- IIntegrationEventHandler<TEvent> — typed event handler contract.
- IEventBus — Publish/Subscribe/Unsubscribe abstraction.
- Registration extensions (AddEventBus) — place to centralize wiring of a concrete IEventBus implementation.

CrossCutting (what to use)
- Logging, caching, correlation-id and middleware abstractions plus DI registration helpers.

---

## Service folder guide — responsibilities and what to extend (no code)

Service root (Services/{Name})
- Purpose: single microservice boundary. Create subprojects (Presentation, Application, Domain, Infrastructure, Tests).
- Action: add ProjectReferences to BuildingBlocks (SharedKernel, EventBus, CrossCutting) where needed.

Presentation (*.API)
- Responsibility: HTTP surface (controllers, routing), API DTOs, filters/middleware, DI entrypoint.
- What to extend:
  - Add controllers that translate HTTP requests to Application use-cases.
  - Add API DTOs for request/response shaping and validation.
  - Add filters and middleware that use CrossCutting abstractions (logging, validation).
  - Register Application and Infrastructure services, event handlers, and call AddEventBus in Program.cs.

Application
- Responsibility: orchestrate use-cases, commands/queries, application DTOs, and publish integration events.
- What to extend:
  - Add Commands/Queries representing use-cases.
  - Implement application services (or handlers) that coordinate repositories, domain services, and transactions.
  - Define application-level interfaces for testability.
  - Publish IntegrationEvent instances when external interested parties must be informed.

Domain
- Responsibility: core business model, aggregates, domain events, domain exceptions, repository interfaces.
- What to extend:
  - Implement Entities inheriting BaseEntity<TId>.
  - Implement immutable ValueObjects for domain invariants.
  - Encapsulate business rules inside aggregates.
  - Define domain-level repository interfaces (e.g., IRecipeRepository) and domain service interfaces.
  - Create domain events for important state changes (local to the service).

Infrastructure
- Responsibility: persistence (DbContext, EF Core), repository implementations, external adapters, concrete IEventBus wiring, migrations.
- What to extend:
  - Add DbContext and entity configurations in Persistence and add EF migrations.
  - Implement Domain repository interfaces using the shared IRepository patterns.
  - Implement external integrations (HTTP clients, file stores, email).
  - Provide or configure a concrete IEventBus implementation and ensure AddEventBus registers it.
  - Create DI registration extensions (e.g., AddRecipesInfrastructure) to group registrations.

Tests
- Responsibility: unit and integration tests for Domain, Application, and Presentation.
- What to extend:
  - Domain.Tests: unit tests for entities, value objects, domain services.
  - Application.Tests: use-case tests with mocks for repositories and IEventBus.
  - API.Tests: integration tests using TestServer or WebApplicationFactory; verify HTTP contracts and event publication.

BuildingBlocks usage and extension points
- SharedKernel:
  - Use BaseEntity, IRepository, and helper types.
  - Extend with additional generic helpers (PagedQuery, Result<T>) if needed.
  - Implement concrete repository behaviors in each service’s Infrastructure.

- EventBus:
  - Define IntegrationEvent types in Application for cross-service notifications.
  - Implement IIntegrationEventHandler<TEvent> in services that consume events.
  - Configure a concrete IEventBus (RabbitMQ, Azure Service Bus, or an in-memory bus for tests) and wire it using AddEventBus. Register event handlers in DI.

- CrossCutting:
  - Use provided abstractions for logging, caching and middleware.
  - Implement concrete middlewares (correlation id, request logging) and registration extensions.

Where to register and wire everything
- Program.cs (Presentation):
  - Call builder.Services.Add{Service}Application() and builder.Services.Add{Service}Infrastructure() extension methods (create these extension methods inside Application/Infrastructure to centralize registrations).
  - Call builder.Services.AddEventBus(configuration) — ensure this registers a concrete IEventBus.
  - Register event handlers (AddTransient<IIntegrationEventHandler<...>, ...>) and any domain services.

Typical checklist for adding a new service
- Domain: add entities, value objects, domain interfaces, domain services.
- Application: add commands/queries, application services, DTOs, define IntegrationEvent types.
- Infrastructure: add DbContext, repository implementations, adapters, migrations, concrete IEventBus wiring.
- Presentation: add controllers, API DTOs, filters, DI wiring in Program.cs.
- Tests: add unit tests (domain/application) and integration tests (API and cross-service flows).
- DI: centralize registrations via extension methods and call them from Program.cs.
- Events: ensure IntegrationEvents and handlers are defined and registered; use an in-memory bus for local tests if needed.

Final pointers
- Keep business rules inside Domain; Application orchestrates use-cases.
- Reuse BuildingBlocks types to maintain consistency and avoid duplication.
- Keep DI registrations small and grouped via extension methods to keep Program.cs readable.
- Provide in-memory implementations for external dependencies (IEventBus, external APIs, DB) to make tests reliable and fast.

---
