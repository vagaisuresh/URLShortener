# URL Shortener

A clean, layered .NET Minimal API project using Domain-Driven Design (DDD), CQRS, and best practices.

## 📁 Project Structure

```plaintext
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