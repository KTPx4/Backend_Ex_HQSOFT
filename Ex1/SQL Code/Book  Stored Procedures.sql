
-- Store get all books
CREATE PROCEDURE GetAllBooks
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Books;
END;


GO

-- Store get book by Id
CREATE PROCEDURE GetBookById
    @BookId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Books WHERE BookId = @BookId;
END;