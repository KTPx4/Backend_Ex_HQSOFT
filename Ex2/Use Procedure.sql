--- Use procedure

use EComDB


GO
-- Filter by day from 20 - 30/03/2025
EXEC sp_GetComplexOrderReport 
    @StartDate = '2025-03-20', 
    @EndDate = '2025-03-30', 
    @CustomerID = NULL, 
    @MinAmount = NULL, 
    @MaxAmount = NULL, 
    @OrderStatus = NULL, 
    @ShipmentStatus = NULL;


GO
-- Filter by customer ID = 6
EXEC sp_GetComplexOrderReport 
    @StartDate = '2025-03-20', 
    @EndDate = '2025-03-30', 
    @CustomerID = 6, 
    @MinAmount = NULL, 
    @MaxAmount = NULL, 
    @OrderStatus = NULL, 
    @ShipmentStatus = NULL;

GO

-- Filter by range of money from  1000 to 2500.
EXEC sp_GetComplexOrderReport 
    @StartDate = '2025-03-20', 
    @EndDate = '2025-03-30', 
    @CustomerID = NULL, 
    @MinAmount = 1000, 
    @MaxAmount = 2500, 
    @OrderStatus = NULL, 
    @ShipmentStatus = NULL;

GO
-- Filter by Status Pending
EXEC sp_GetComplexOrderReport 
    @StartDate = '2025-03-20', 
    @EndDate = '2025-03-30', 
    @CustomerID = NULL, 
    @MinAmount = NULL, 
    @MaxAmount = NULL, 
    @OrderStatus = 'Pending', 
    @ShipmentStatus = NULL;

GO
-- Filter by Delivery Status Success
EXEC sp_GetComplexOrderReport 
    @StartDate = '2025-03-20', 
    @EndDate = '2025-03-30', 
    @CustomerID = NULL, 
    @MinAmount = NULL, 
    @MaxAmount = NULL, 
    @OrderStatus = NULL, 
    @ShipmentStatus = 'Delivered';


