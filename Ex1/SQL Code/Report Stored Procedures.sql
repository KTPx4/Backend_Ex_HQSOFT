CREATE PROCEDURE SearchBooks
    @SearchKey NVARCHAR(200) = NULL,
    @AuthorId INT = NULL,
    @FromPublishedDate DATETIME = NULL,
    @ToPublishedDate DATETIME = NULL,
    @PageSize INT = 10,
    @PageIndex INT = 1
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Offset INT = (@PageIndex - 1) * @PageSize;
    
    SELECT *
    FROM Books
    WHERE (@SearchKey IS NULL OR Title LIKE '%' + @SearchKey + '%')
      AND (@AuthorId IS NULL OR AuthorId = @AuthorId)
      AND (@FromPublishedDate IS NULL OR PublishedDate >= @FromPublishedDate)
      AND (@ToPublishedDate IS NULL OR PublishedDate <= @ToPublishedDate)
    ORDER BY PublishedDate DESC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
END;
