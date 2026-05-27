# Clean Architecture

## .NET CLI Commands

### 🧹 Cleanup

```bash
rm -rf *
# ⚠️ Removes all files and folders in the current directory (destructive)

 dotnet clean
# Cleans build outputs (bin/obj folders)
```

---

### 📦 Restore & Build

```bash
dotnet restore
# Restores NuGet packages

 dotnet build
# Builds the project/solution
```

---

### 🏗️ Project Setup

```bash
dotnet new list
# Lists available templates

 dotnet new sln -n CleanArchitecture --format sln
# Creates a solution file
```

---

### 🌐 Web API

```bash
dotnet new webapi -n CleanArchitecture.WebApi -f net8.0 --use-controllers --use-program-main --force
# Creates a Web API project

 dotnet run --project src/CleanArchitecture.WebApi
# Runs the Web API project
```

---

### 🔐 Certificate Setup

```bash
dotnet dev-certs https --trust
# Generates and trusts a local HTTPS development certificate
```

---

### 🧾 Code Generation

```bash
dotnet new class \
  -n AppDbContext \
  -o "src/External/CleanArchitecture.Persistance/Context"
# Creates a new class in the specified folder
```

---

### 🗄️ Database (EF Core)

#### Install EF Core SQL Server provider

```bash
dotnet add "src/External/CleanArchitecture.Persistance/CleanArchitecture.Persistance.csproj" \
  package Microsoft.EntityFrameworkCore.SqlServer --version 8.*
```

#### Install EF CLI tool

```bash
dotnet tool install --global dotnet-ef
```

#### Create Migration

```bash
dotnet ef migrations add mg1 \
  --project src/External/CleanArchitecture.Persistance \
  --startup-project src/CleanArchitecture.WebApi
```

#### Update Database

```bash
dotnet ef database update \
  --project src/External/CleanArchitecture.Persistance \
  --startup-project src/CleanArchitecture.WebApi
```

---

### 🔌 Database Connection (Team Setup)

The committed connection string in `src/CleanArchitecture.WebApi/appsettings.json` defaults to **LocalDB**:

```
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CleanArchitectureDb;Integrated Security=True;TrustServerCertificate=True
```

LocalDB ships with the .NET SDK / Visual Studio, so this works out-of-the-box on most Windows dev machines with **no SQL Server install required**. The database name (`CleanArchitectureDb`) is the same for everyone — only the *server* may differ per developer.

**Do not commit your personal server name into `appsettings.json`.** If you use a different SQL Server (e.g. `SQLEXPRESS`, a named instance, or a remote server), override the connection string locally using one of the following — both take precedence over `appsettings.json` with no code changes:

**Option A — User Secrets (recommended for local dev, never committed):**

```bash
dotnet user-secrets set "ConnectionStrings:SqlServer" "Data Source=.\SQLEXPRESS;Initial Catalog=CleanArchitectureDb;Integrated Security=True;TrustServerCertificate=True" \
  --project src/CleanArchitecture.WebApi
```

**Option B — Environment variable (great for CI / Docker; `__` maps to the nested key):**

```bash
# PowerShell
$env:ConnectionStrings__SqlServer = "Data Source=.\SQLEXPRESS;Initial Catalog=CleanArchitectureDb;Integrated Security=True;TrustServerCertificate=True"
```

After overriding, run the `dotnet ef database update` command above to create the database on your chosen server.

---

### 🧪 Testing

#### Create test project

```bash
dotnet new xunit -n CleanArchitecture.UnitTest -f net8.0
```

#### Add project reference

```bash
dotnet add "C:\dev\clean-arch-train\src\CleanArchitecture.WebApi\CleanArchitecture.WebApi.csproj" \
  reference "C:\dev\clean-arch-train\src\Core\CleanArchitecture.Application\CleanArchitecture.Application.csproj"
```

#### Run tests

```bash
cd test/CleanArchitecture.UnitTest
 dotnet test
```

---

### 🧮 SQL Server Commands

```sql
sqlcmd -S localhost\SQLEXPRESS -d master -C

USE CleanArchitectureDb;
GO

SELECT name FROM sys.tables;
GO

SELECT * FROM __EFMigrationsHistory;
GO

SELECT * FROM ErrorLogs;
GO
```

---

## 📚 Credits

This project is based on and inspired by **Taner Saydam's _"Clean Architecture Öğrenelim"_ training**.
