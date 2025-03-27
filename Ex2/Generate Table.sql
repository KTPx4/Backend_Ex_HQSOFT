------------- Create table---------------
Create DATABASE EComDB

GO

USE EComDB

GO

-- Create table Customers
CREATE TABLE Customers (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL
);

GO

-- Create table Orders
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(ID),
    OrderDate DATE NOT NULL,
    Status VARCHAR(50) NOT NULL
);

GO

-- Create table Products
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(255) NOT NULL,
    Category VARCHAR(100),
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL
);

GO

-- Create table OrderItems
CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL
);

GO

-- Create table Shipments
CREATE TABLE Shipments (
    ShipmentID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ShipmentDate DATE,
    DeliveryStatus VARCHAR(50)
);


------------- Insert Value---------------
-- Insert Customers
INSERT INTO Customers (Name, Email) VALUES
('Nguyen Van A', 'nguyenvana@example.com'),
('Tran Thi B', 'tranthib@example.com'),
('Le Van C', 'levanc@example.com'),
('Pham Thi D', 'phamthid@example.com'),
('Hoang Van E', 'hoangvane@example.com'),
('Nguyen Van F', 'nguyenvanf@example.com'),
('Tran Thi G', 'tranthig@example.com'),
('Le Van H', 'levanh@example.com'),
('Pham Thi I', 'phamthii@example.com'),
('Hoang Van J', 'hoangvanj@example.com');

-- Insert Products
INSERT INTO Products (ProductName, Category, Price, Stock) VALUES
('Laptop Dell XPS', 'Electronics', 1200.00, 10),
('iPhone 15', 'Mobile', 999.99, 15),
('Bàn phím cơ Logitech', 'Accessories', 89.99, 30),
('Tai nghe Sony WH-1000XM4', 'Audio', 299.99, 20),
('Chuột không dây Razer', 'Accessories', 59.99, 25),
('MacBook Pro 14', 'Electronics', 2000.00, 8),
('Samsung Galaxy S24', 'Mobile', 1099.99, 12),
('Bàn Gaming RGB', 'Furniture', 150.00, 20),
('Loa Bluetooth JBL', 'Audio', 99.99, 25),
('Sạc nhanh Anker 65W', 'Accessories', 49.99, 30);

-- Insert Orders
INSERT INTO Orders (CustomerID, OrderDate, Status) VALUES
(1, '2025-03-20', 'Pending'),
(2, '2025-03-21', 'Shipped'),
(3, '2025-03-22', 'Delivered'),
(4, '2025-03-23', 'Pending'),
(5, '2025-03-24', 'Shipped'),
(6, '2025-03-25', 'Pending'),
(7, '2025-03-26', 'Shipped'),
(8, '2025-03-27', 'Delivered'),
(9, '2025-03-28', 'Pending'),
(10, '2025-03-29', 'Cancelled');

-- Insert OrderItems
INSERT INTO OrderItems (OrderID, ProductID, Quantity, Price) VALUES
(1, 1, 1, 1200.00),  -- Laptop Dell XPS
(1, 3, 2, 89.99),    -- Bàn phím cơ Logitech
(2, 2, 1, 999.99),   -- iPhone 15
(3, 4, 1, 299.99),   -- Tai nghe Sony WH-1000XM4
(4, 5, 3, 59.99),    -- Chuột không dây Razer
(6, 6, 1, 2000.00),   -- MacBook Pro 14
(6, 8, 2, 150.00),    -- Bàn Gaming RGB
(7, 7, 1, 1099.99),   -- Samsung Galaxy S24
(8, 9, 3, 99.99),     -- Loa Bluetooth JBL
(9, 10, 4, 49.99);    -- Sạc nhanh Anker 65W

-- Insert Shipments
INSERT INTO Shipments (OrderID, ShipmentDate, DeliveryStatus) VALUES
(2, '2025-03-22', 'In Transit'),
(3, '2025-03-23', 'Delivered'),
(5, '2025-03-25', 'In Transit'),
(1, NULL, 'Processing'),
(4, NULL, 'Pending'),
(7, '2025-03-27', 'In Transit'),
(8, '2025-03-28', 'Delivered'),
(10, '2025-03-30', 'Cancelled'),
(6, NULL, 'Processing'),
(9, NULL, 'Pending');
