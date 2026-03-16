# Clean Architecture Demo: Barber Booking API

An ongoing project designed as a proof-of-concept for Clean Architecture in .NET. It features a rich domain model, MediatR-based CQRS, and global exception handling. Focused on maintainability, testability, and decoupled design.

WORK IN PROGRESS

### Architecture Layers:
- **Domain**: Pure business logic (Entities, Value Objects).
- **Application**: Use cases, MediatR handlers, and Validators.
- **Infrastructure**: Persistence (EF Core) and external services.
- **API**: Thin controllers and Middleware.