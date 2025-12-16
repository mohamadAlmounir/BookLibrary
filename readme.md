# 📚 BookLibrary API

BookLibrary is a **RESTful Web API** built with **ASP.NET Core** that provides basic library management functionality. The API allows clients to perform full **CRUD operations** (Create, Read, Update, Delete) on books stored in a SQL Server database using **Entity Framework Core**.

This project was created as part of a **Backend Developer portfolio** to demonstrate clean architecture, proper separation of concerns, and best practices when building APIs with .NET.

---

## 🧱 Project Architecture

The solution is structured using a **layered architecture**, which helps keep the code clean, maintainable, and scalable.

```
BookLibrary
│
├── BooksLibrary.API      → API layer (Controllers, Program.cs)
├── BooksLibrary.Core     → Domain layer (Entities, Interfaces)
├── BooksLibrary.EF       → Data access layer (DbContext, Repositories)
└── BooksLibrary.sln
```

### Layers Overview

- **API Layer**
  - Handles HTTP requests and responses
  - Contains Controllers and API configuration

- **Core Layer**
  - Contains domain entities (Book, etc.)
  - Defines interfaces and business contracts

- **EF Layer**
  - Implements data access logic using Entity Framework Core
  - Contains DbContext and repository implementations

---

## ✨ Features

- 📌 Create a new book
- 📌 Retrieve all books
- 📌 Retrieve a single book by ID
- 📌 Update existing book information
- 📌 Delete a book
- 📌 RESTful endpoints following HTTP standards
- 📌 Swagger UI for API documentation and testing

---

## 🛠️ Technologies Used

- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server / LocalDB**
- **Swagger (OpenAPI)**
- **Repository Pattern**

---

## ⚙️ Prerequisites

Before running the project, make sure you have the following installed:

- ✅ .NET SDK 7 or later
- ✅ SQL Server (LocalDB, Express, or Full)
- ✅ Visual Studio 2022+ or Visual Studio Code
- ✅ Git

---

## ▶️ How to Run the Project Locally

Follow these steps carefully to run the project on your local machine.

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/mohamadAlmounir/BookLibrary.git
cd BookLibrary
```

---

### 2️⃣ Open the Solution

- Using **Visual Studio**:
  - Open `BookLibrary.sln`

- Using **VS Code**:
  - Open the root folder of the project

---

### 3️⃣ Configure the Database Connection

Open the `appsettings.json` file inside the **API project** and update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BookLibraryDB;Trusted_Connection=True;"
}
```

> You can replace `localdb` with your SQL Server instance if needed.

---

### 4️⃣ Apply Database Migrations

Using **Visual Studio (Package Manager Console)**:

```powershell
Add-Migration InitialCreate
Update-Database
```

Or using **.NET CLI**:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create the database and required tables automatically.

---

### 5️⃣ Run the API

- In **Visual Studio** press **F5** or **Ctrl + F5**
- Or using the CLI:

```bash
dotnet run --project BooksLibrary.API
```

Once the application is running, the browser will open **Swagger UI** automatically.

---

## 📖 API Documentation (Swagger)

Swagger provides an interactive UI to test all endpoints.

After running the project, navigate to:

```
https://localhost:{PORT}/swagger
```

From there you can send requests, view schemas, and test responses.

---

## 📡 Available Endpoints

| HTTP Method | Endpoint             | Description                 |
|------------|----------------------|-----------------------------|
| GET        | /api/books            | Get all books               |
| GET        | /api/books/{id}       | Get book by ID              |
| POST       | /api/books            | Create a new book           |
| PUT        | /api/books/{id}       | Update an existing book     |
| DELETE     | /api/books/{id}       | Delete a book               |

---

## 🧪 Testing (Recommended Improvement)

Currently, the project does not include automated tests.

Suggested additions:
- Unit Tests using **xUnit** or **NUnit**
- Integration Tests for Controllers

Adding tests will significantly improve code quality and reliability.

---

## 🚀 Future Improvements

- 🔐 Authentication & Authorization (JWT)
- 🔍 Search and filtering functionality
- 📄 Pagination support
- 🧪 Unit & Integration tests
- 🔄 CI/CD using GitHub Actions

---

## 👨‍💻 Author

**Mohamad Almounir**  
Backend Developer (.NET)

GitHub: https://github.com/mohamadAlmounir

---

## 📜 License

This project is open-source and intended for learning and portfolio purposes.
You are free to use and extend it.

