# URL Shortener

A clean, layered .NET Minimal API project using Domain-Driven Design (DDD), CQRS, and best practices.

## 📁 Project Structure

```
/URLShortener
├── 📁 docs                    # 📚 Architecture & setup documentation
│   ├── architecture.md
│   ├── setup.md
│   └── diagrams/
│       └── architecture.png
│
├── 📁 src                                  # 🧠 Main application code
│   ├── 📁 URLShortener.API                 # 🌐 Minimal API layer
|   |   ├── 📁 Context                      # 🧱 Infrastructure layer (Infrastructure/Persistence/Context)
│   |   │   └── ApplicationDbContext.cs
│   │   ├── 📁 DIs                          # 🌐 Minimal API layer
│   |   │   ├── DependencyBindings.cs
│   |   │   └── ServiceRegistrations.cs
│   │   ├── 📁 DTOs                         # 🌐 Minimal API layer
│   │   ├── 📁 Endpoints                    # 🌐 Minimal API layer
│   │   ├── 📁 Interfaces                   # ⚙️ Application layer (Application/Interfaces & Application/Common/Interfaces)
│   |   │   ├── IShortIdGenerator.cs
│   |   │   └── IShortUrlService.cs
│   │   ├── 📁 Services                     # ⚙️ Application layer (Application/Services)
|   |   ├── 📁 Utilities                    # 🧱 Infrastructure layer (Infrastructure/Utilities)
│   |   │   └── ShortIdGenerator.cs
│   │   ├── Program.cs
│   │   ├── appsettings.json
|
│   │   ├── 📁 Endpoints
│   │   ├── 📁 DTOs
│   │   ├── 📁 Middleware
│   │   └── 📁 DependencyInjection
│   │
│   ├── 📁 Application         # ⚙️ Application layer (CQRS, services, interfaces)
│   │   ├── 📁 Services
│   │   ├── 📁 Commands
│   │   ├── 📁 Queries
│   │   ├── 📁 DTOs
│   │   └── 📁 Interfaces
│   │
│   ├── 📁 Domain              # 🧩 Core business logic
│   │   ├── 📁 Entities
│   │   ├── 📁 ValueObjects
│   │   ├── 📁 Interfaces
│   │   └── 📁 Events
│   │
│   └── 📁 Infrastructure      # 🧱 External services, persistence
│       ├── 📁 Persistence
│       │   ├── ApplicationDbContext.cs
│       │   └── 📁 Repositories
│       ├── 📁 ExternalServices
│       └── 📁 Configuration
│
├── 📁 tests                   # 🧪 Unit and integration tests
│   ├── Application.Tests
│   ├── Domain.Tests
│   └── API.Tests
│
├── .gitignore
├── URLShortener.sln           # 🔗 Visual Studio solution file
└── README.md                  # 📘 Entry-point project description
```

## 📁 Proposed Project Structure

```
/URLShortener
├── 📁 .github                 # (Optional) GitHub workflows, issue templates, etc.
│   └── workflows
│       └── ci.yml
│
├── 📁 docs                    # 📚 Architecture & setup documentation
│   ├── architecture.md
│   ├── setup.md
│   └── diagrams/
│       └── architecture.png
│
├── 📁 src                     # 🧠 Main application code
│   ├── 📁 API                 # 🌐 Minimal API layer
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   ├── 📁 Endpoints
│   │   ├── 📁 DTOs
│   │   ├── 📁 Middleware
│   │   └── 📁 DependencyInjection
│   │
│   ├── 📁 Application         # ⚙️ Application layer (CQRS, services, interfaces)
│   │   ├── 📁 Services
│   │   ├── 📁 Commands
│   │   ├── 📁 Queries
│   │   ├── 📁 DTOs
│   │   └── 📁 Interfaces
│   │
│   ├── 📁 Domain              # 🧩 Core business logic
│   │   ├── 📁 Entities
│   │   ├── 📁 ValueObjects
│   │   ├── 📁 Interfaces
│   │   └── 📁 Events
│   │
│   └── 📁 Infrastructure      # 🧱 External services, persistence
│       ├── 📁 Persistence
│       │   ├── ApplicationDbContext.cs
│       │   └── 📁 Repositories
│       ├── 📁 ExternalServices
│       └── 📁 Configuration
│
├── 📁 tests                   # 🧪 Unit and integration tests
│   ├── Application.Tests
│   ├── Domain.Tests
│   └── API.Tests
│
├── .gitignore
├── URLShortener.sln           # 🔗 Visual Studio solution file
└── README.md                  # 📘 Entry-point project description
```

```
MS SQL Server
---
CREATE TABLE ShortUrls (
    Id INT PRIMARY KEY IDENTITY(1,1),
    LongUrl TEXT NOT NULL,
    ShortId VARCHAR(10) NOT NULL,
    Domain VARCHAR(255) NOT NULL,
    ShortUrlValue VARCHAR(255) NOT NULL,
    Description NVARCHAR(255),
    ExpireAtDateTime DATETIME,
    ExpireAtViews INT,
    PublicStats BIT,
    HasPassword BIT NOT NULL,
    CreatedAtDateTime DATETIME,
    UpdatedAtDateTime DATETIME
);
```
