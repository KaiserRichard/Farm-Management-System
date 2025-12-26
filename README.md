# Farm Management System (Clean Architecture)

A robust, enterprise-grade Livestock and Farm Management solution developed using **ASP.NET Core 8**. This project implements **Clean Architecture** principles to ensure high maintainability, scalability, and separation of concerns.

## 🚀 Key Features

- **Identity & Security**: Secure authentication and authorization using **ASP.NET Core Identity**. Implements Role-Based Access Control (RBAC) for Admin and Staff.
- **Farm & Livestock Tracking**: Efficient CRUD operations to manage farm locations and animal health records across multiple sites.
- **Inventory Management**: Real-time tracking of farm supplies (feed, medicine). Features low-stock alerts and transaction history.
- **Automated Vaccination Workflows**: A smart medical module that automatically deducts medicine stock from inventory upon vaccination confirmation.
- **Interactive Dashboard**: Provides high-level statistical summaries of farm productivity and livestock health.

## 🛠 Tech Stack

- **Framework**: .NET 8 (ASP.NET Core MVC)
- **Database**: MySQL (Entity Framework Core)
- **Architecture**: Clean Architecture (4-Layer: Core, UseCases, Infrastructure, Web UI)
- **Frontend**: Bootstrap 5, FontAwesome, jQuery

## 📂 Project Structure

- `CoreBusiness`: Domain entities and business logic.
- `UseCases`: Application logic and repository interfaces.
- `Plugins.DataStore.SQL`: Infrastructure layer handling MySQL data persistence.
- `WebApp`: Presentation layer (MVC) and Identity configuration.

## ⚙️ Installation & Setup

1. **Database**: Import the provided `FarmManagement_Backup.sql` file into your MySQL Server.
2. **Configuration**: Update the `DefaultConnection` string in `WebApp/appsettings.json` with your MySQL credentials.
3. **Run**:
   ```bash
   dotnet restore
   dotnet run --project WebApp
