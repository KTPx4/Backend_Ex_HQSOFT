--- Create procedure

use EComDB

GO

CREATE PROCEDURE sp_GetComplexOrderReport
    @StartDate DATE,
    @EndDate DATE,
    @CustomerID INT = NULL,
    @MinAmount DECIMAL(18,2) = NULL,
    @MaxAmount DECIMAL(18,2) = NULL,
    @OrderStatus VARCHAR(50) = NULL,
    @ShipmentStatus VARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        o.OrderID,
        o.OrderDate,
        c.Name AS CustomerName,
        SUM(oi.Quantity * oi.Price) AS TotalAmount,
        SUM(oi.Quantity) AS TotalQuantity,
        s.ShipmentDate,
        s.DeliveryStatus,
        o.Status AS OrderStatus

    FROM Orders o
    JOIN Customers c ON o.CustomerID = c.ID
    JOIN OrderItems oi ON o.OrderID = oi.OrderID
    LEFT JOIN Shipments s ON o.OrderID = s.OrderID
    WHERE 
        o.OrderDate BETWEEN @StartDate AND @EndDate
        AND (@CustomerID IS NULL OR o.CustomerID = @CustomerID)
        AND (@MinAmount IS NULL OR 
									(
										SELECT SUM(oi2.Quantity * oi2.Price) 
										FROM OrderItems oi2 
										WHERE oi2.OrderID = o.OrderID
									) >= @MinAmount)

        AND (@MaxAmount IS NULL OR 
									(
										SELECT SUM(oi3.Quantity * oi3.Price) 
										FROM OrderItems oi3 
										WHERE oi3.OrderID = o.OrderID
									) <= @MaxAmount)

        AND (@OrderStatus IS NULL OR o.Status = @OrderStatus)
        AND (@ShipmentStatus IS NULL OR s.DeliveryStatus = @ShipmentStatus)
    GROUP BY o.OrderID, o.OrderDate, c.Name, s.ShipmentDate, s.DeliveryStatus, o.Status
    ORDER BY o.OrderDate DESC;
END;


