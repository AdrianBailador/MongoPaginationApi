# MongoPaginationApi

This is a simple RESTful API built with **.NET** and **MongoDB**, featuring **pagination** to manage large datasets efficiently. The API demonstrates how to interact with MongoDB, implement pagination, and test the API with sample data.

## Features

- **RESTful API** with **.NET**.
- Pagination support to efficiently handle large datasets using **MongoDB**.
- Insert 100 sample products into the database for testing.
- Swagger integration for easy API testing.

## Prerequisites

Before running the project, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet)
- [MongoDB](https://www.mongodb.com/try/download/community) or [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) (cloud service)
- A code editor like [Visual Studio Code](https://code.visualstudio.com/).

## Setup

### 1. Clone the Repository

```bash
git clone https://github.com/AdrianBailador/MongoPaginationApi.git
cd MongoPaginationApi
```

### 2. Install Dependencies

Make sure you have the **MongoDB.Driver** package installed. If not, run the following command:

```bash
dotnet add package MongoDB.Driver
```

### 3. Configure MongoDB

In the **appsettings.json** file, configure your MongoDB connection string, database name, and collection name:

```json
{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",  // Update with your MongoDB connection string
    "DatabaseName": "ProductDb",
    "CollectionName": "Products"
  }
}
```

### 4. Run the Application

Start the API with the following command:

```bash
dotnet run
```

This will start the API on **http://localhost:5000**.

### 5. Access Swagger

Once the application is running, open **http://localhost:5000/swagger** to interact with the API. You can test pagination by specifying `page` and `pageSize` parameters.

## API Endpoints

- **GET /api/products**  
  Fetches paginated product data.  
  **Parameters:**
  - `page` (default: 1)
  - `pageSize` (default: 10)

### Example Request:

```http
GET /api/products?page=2&pageSize=10
```

## Seeder

The application includes a **Seeder** that will insert 100 sample products into the MongoDB database when the application starts. You can customize the product data as needed.

## Technologies Used

- **.NET 8** for the backend.
- **MongoDB** for database storage.
- **Swagger** for API testing.
