# NZWalks API

This project is an ASP.NET Core Web API for managing regions and walks in New Zealand, created as part of a course on ASP.NET Core Web API development.

## Technologies Used

- **.NET 8**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**
- **AutoMapper**
- **Swagger**
- **Postman**

## Features

- **RESTful API**: Follows REST principles.
- **CRUD Operations**: Create, Read, Update, and Delete operations for regions and walks.
- **Authentication and Authorization**: Implemented using JWT tokens and ASP.NET Core Identity.
- **Filtering, Sorting, and Pagination**: Advanced data retrieval features.
- **Asynchronous Programming**: Utilizes async/await for better performance.
- **Clean Architecture**: Domain and data models, repository pattern, and dependency injection.

## Setup Instructions

1. **Clone the repository**:
    ```bash
    git clone https://github.com/Ahmed-El-sayed-Mahmoud/NZWalks.API.git
    cd NZWalks.API
    ```

2. **Set up the database**:
    - Install SQL Server if you haven't already.
    - Update the connection string in `appsettings.json` to point to your SQL Server instance.
    - Run the following commands to apply migrations and create the database:
      ```bash
      dotnet ef database update
      ```

3. **Run the project**:
    ```bash
    dotnet run
    ```

4. **Test the API**:
    - Open your browser and navigate to `https://localhost:{PORT}/swagger` to access the Swagger UI.
    - Use Postman or any other API testing tool to interact with the API endpoints.

## API Endpoints

- **Regions**:
  - `GET /api/regions` - Get all regions.
  - `GET /api/regions/{id}` - Get a specific region.
  - `POST /api/regions` - Create a new region.
  - `PUT /api/regions/{id}` - Update an existing region.
  - `DELETE /api/regions/{id}` - Delete a region.

- **Walks**:
  - `GET /api/walks` - Get all walks.
  - `GET /api/walks/{id}` - Get a specific walk.
  - `POST /api/walks` - Create a new walk.
  - `PUT /api/walks/{id}` - Update an existing walk.
  - `DELETE /api/walks/{id}` - Delete a walk.

## Authentication

- **Register**: `POST /api/auth/register` - Register a new user.
- **Login**: `POST /api/auth/login` - Authenticate a user and get a JWT token.

## Advanced Features

- **Filtering, Sorting, and Pagination**: Add query parameters for filtering, sorting, and pagination to the `GET /api/walks` endpoint.
- **Role-Based Authorization**: Secure endpoints with roles and permissions.

## Tools

- **Swagger UI**: For testing and documenting the API.
- **Postman**: For testing API endpoints.
- **AutoMapper**: For object-to-object mapping.

## Contribution

Contributions are welcome! Please create an issue or submit a pull request with your changes.
