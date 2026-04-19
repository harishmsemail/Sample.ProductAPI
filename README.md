# Sample Product API

A sample ASP.NET Core Web API for managing a product catalog. This project demonstrates best practices for building a clean, maintainable, and well-structured RESTful service.

## Features

- **Product Management**: Endpoints to retrieve all products or a single product by its ID.
- **Product Attributes**: Endpoint to retrieve all attributes for a specific product.
- **Structured Logging**: Integrated with Serilog for structured, filterable application logs.
- **Global Error Handling**: Centralized exception handling to ensure consistent and safe error responses.
- **Clean Architecture Principles**:
  - **Repository Pattern**: Decouples data access logic from the business layer.
  - **DTOs (Data Transfer Objects)**: Ensures a clean separation between internal models and the API's public contract.
  - **Dependency Injection**: Leverages .NET's built-in DI container for loosely coupled components.

## Technologies Used

- **[.NET 8]** .Net runtime
- **[ASP.NET Core]** Web framework for building APIs.
- **[Entity Framework Core]** Object-database mapper for .NET.
  - **In-Memory Database**: Used for demonstration purposes to allow the project to run without an external database.
- **[Serilog]** Structured logging library for .NET.
- **[Swagger (Swashbuckle)]** API documentation and and interactive testing.

## Getting Started

### Prerequisites

- [.NET 8 SDK]
- A code editor like [Visual Studio] or [VS Code]

### Setup and Running the Application

1. **Clone the repository:**
   ```bash
   git clone <your-repository-url>
   ```
2. **Navigate to the project directory:**
   ```bash
   cd SampleProductApi
   ```
3. **Run the application:**
   ```bash
   dotnet run
   ```
The API will start and listen on the configured ports (e.g., `https://localhost:7123` and `http://localhost:5123`).

4. **Access the Swagger UI:**
Open your web browser and navigate to `https://localhost:7123/swagger` to view the interactive API documentation.

## API Endpoints

### GET /api/products

Retrieves a list of all products.

- **Success Response:**
- `200 OK` - Returns an array of product objects.
- **Error Response:**
- `500 Internal Server Error` - An unexpected error occurred on the server.

---

### GET /api/products/{id}

Retrieves a single product by its unique identifier.

- **Parameters:**
- `id` (integer): The ID of the product to retrieve.
- **Success Response:**
- `200 OK` - Returns the product object.
- **Error Responses:**
- `404 Not Found` - The product with the specified ID does not exist.
- `500 Internal Server Error` - An unexpected error occurred on the server.

---

### GET /api/products/{id}/attributes

Retrieves all attributes for a specific product.

- **Parameters:**
  - `id` (integer): The ID of the product whose attributes are to be retrieved.
- **Success Response:**
  - `200 OK` - Returns an array of product attribute objects.
- **Error Response:**
  - `500 Internal Server Error` - An unexpected error occurred on the server.

---
