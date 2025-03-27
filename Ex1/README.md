# Book Management API

## Project Overview
This project is developed using **ASP.NET Core API** with **MSSQL** as the database.

## Setup Instructions

### 1. Configure the Database Connection
- Open `appsettings.json`.
- Update the connection string to match your database configuration.

### 2. Build the Project
- Ensure that all dependencies are installed.
- Use Visual Studio or the .NET CLI to build the project.

### 3. Apply Database Migrations
- Open the "Package Manager Console" in Visual Studio.
- Run the following command to apply database migrations:
  ```powershell
  update-database
  ```

### 4. Run SQL Scripts (Optional)
- Navigate to the `SQL Code` folder.
- Execute the provided SQL scripts in your MSSQL database if required.

### 5. Start the Project
API will be available at `https://localhost:7000/api`.


### 6. API Testing
- Use **Postman** to test the API endpoints.
- Join the Postman team using the following link:
  [Postman Team Invitation](https://app.getpostman.com/join-team?invite_code=3a7265e8abf209df07e0758a1529436fe896dfdab9bb22921e050d9e5438db70&target_code=2733adc1c3fa3fe55491d75ea2e52010)


## Book Management API

## Overview
This API provides functionalities to manage books and authors, including creating, updating, and searching books based on filters.

## Base URL
```
https://localhost:7000/api
```

---

## **BookController**

### **1. Create a Book**
**Endpoint:**
```
POST /books/insert
```
**Request Body:**
```json
{
  "title": "Book Title",
  "price": 19.99,   
  "publishedDate": "2024-03-20",
  "authorId": 1,
}
```
**Response:**
```json
{
  "message": "Book created successfully",
  "data": {
    "bookId": 1,  
    "title": "Book Title",
    "price": 19.99,
    "authorId": 1,
    "publishedDate": "2024-03-20"
  }
}
```

### **2. Update a Book**
**Endpoint:**
```
PUT /books/update
```
**Request Body:**
```json
{
  "bookId": 1,
  "title": "Updated Title",
  "price": 24.99,
  "authorId": 2,
  "publishedDate": "2024-03-22"
}
```
**Response:**
```json
{
  "message": "Update book successful",
  "data": {
    "bookId": 1,
    "title": "Updated Title",
    "price": 24.99,
    "authorId": 2,
    "publishedDate": "2024-03-22"
  }
}
```

### **3. Get all books**
**Endpoint:**
```
GET /books/fetch
```
**Request Body:**
```json
{
  
}
```
**Response:**
```json
{
  "message": "Get books successful",
  "length": 2,
  "data": [
    {
      "bookId": 1,
      "title": "Updated Title",
      "price": 24.99,
      "authorId": 2,
      "publishedDate": "2024-03-22"
    },
    {
      "bookId": 2,
      "title": "Book example 2",
      "price": 34.22,
      "authorId": 2,
      "publishedDate": "2024-03-22"
    }
  ]
}
```

### **4. Get book by Id**
**Endpoint:**
```
GET /books/fetch/{BookId}
```
**Request Body:**
```json
{
  
}
```
**Response:**
```json
{
  "message": "Get book successful",
  "data": {
      "bookId": 1,
      "title": "Updated Title",
      "price": 24.99,
      "authorId": 2,
      "publishedDate": "2024-03-22"
    }
}
```

### **5. Delete book by Id**
**Endpoint:**
```
DELETE /books/fetch/{id}
```
**Request Body:**
```json
{
  
}
```
**Response:**
```json
{
  "message": "Delete book successful",
  "data": {
      "bookId": 1,
      "title": "Updated Title",
      "price": 24.99,
      "authorId": 2,
      "publishedDate": "2024-03-22"
    }
}
```

---

## **AuthorController**

### **1. Create an Author**
**Endpoint:**
```
POST /authors
```
**Request Body:**
```json
{
  "name": "Author Name",
  "bio": "Short biography"
}
```
**Response:**
```json
{
  "message": "Author created successfully",
  "data": {
    "authorId": 1,  
    "name": "Author Name",
    "bio": "Short biography"
  }
}
```

### **2. Update an Author**
**Endpoint:**
```
PUT /authors/update
```
**Request Body:**
```json
{
  "authorId": 1,
  "name": "Updated Name",
  "bio": "Updated biography"
}
```
**Response:**
```json
{
  "message": "Author updated successfully",
  "data": {
    "authorId": 1,
    "name": "Updated Name",
    "bio": "Updated biography"
  }
}
```

### **3. Get all authors**
**Endpoint:**
```
GET /authors/fetch
```
**Request Body:**
```json
{
 
}
```
**Response:**
```json
{
  "message": "Get authors successfully",
  "length": 2,
  "data": [
    {
      "authorId": 1,
      "name": "Updated Name",
      "bio": "Updated biography"
    },
    {
        "authorId": 2,
        "name": "Author example 2",
        "bio": "example biography"
    }
  ]
}
```

### **4. Get author by Id**
**Endpoint:**
```
GET /authors/fetch/{AuthorId}
```
**Request Body:**
```json
{
 
}
```
**Response:**
```json
{
  "message": "Get author successfully",
  "data":
  {
      "authorId": 1,
      "name": "Updated Name",
      "bio": "Updated biography"
  }
}
```


### **5. Delete author by Id**
**Endpoint:**
```
DELETE /authors/fetch/{AuthorId}
```
**Request Body:**
```json
{
 
}
```
**Response:**
```json
{
  "message": "Delete author successfully", 
  "data":
  {
      "authorId": 1,
      "name": "Updated Name",
      "bio": "Updated biography"
  }
}
```
---

## **ReportController**

### **1. Search Books with Filters**
**Endpoint:**
```
GET /reports/book
```
**Query Parameters:**
- `searchKey` (optional): Keyword to search books by title
- `authorId` (optional): Filter books by a specific author
- `fromPublishedDate` (optional): Start date for filtering books
- `toPublishedDate` (optional): End date for filtering books
- `pageSize` (required): Number of books per page
- `pageIndex` (required): Page number

**Example Request:**
```
GET /reports/book?searchKey=history&authorId=2&fromPublishedDate=2022-01-01&toPublishedDate=2024-01-01&pageSize=10&pageIndex=1
```

**Response:**
```json
{
  "pageIndex": 1,
  "pageSize": 10,
  "totalBooks": 50,
  "books": [
    {
      "bookId": 1,
      "title": "Sample Book",
      "authorId": 1,
      "publishedDate": "2023-06-15",
      "price": 19.99
    },
    {
      "bookId": 2,
      "title": "Another Book",
      "authorId": 2,
      "publishedDate": "2022-09-20",
      "price": 25.50
    }
  ]
}
```

---

## **Error Handling**
| Status Code | Description |
|------------|-------------|
| 400 | Bad Request - Invalid input |
| 404 | Not Found - Resource not found |
| 500 | Internal Server Error - Something went wrong |

---

 

 


