# Brasileira-se - Backend (API)

API desenvolvida em .NET 8 para o gerenciamento de dados do projeto Brasileira-se.

## Tecnologias
- **Linguagem:** C#
- **Framework:** ASP.NET Core Web API
- **Banco de Dados:** SQLite
- **ORM:** Entity Framework Core

## Estrutura de Pastas
- `Controllers/`: Endpoints da API (`Estados`, `PontoTuristico`).
- `Data/`: Contexto do banco de dados (`AppDbContext.cs`).
- `Models/`: Classes de representação de dados (`Estados.cs`, `PontoTuristico.cs`).
- `app.db`: Arquivo físico do banco de dados SQLite.

## Como Executar
1. Certifique-se de ter o **.NET 8 SDK** instalado.
2. Compile o projeto:
   ```bash
    dotnet bin/Debug/net8.0/api_brasileira-se.dll