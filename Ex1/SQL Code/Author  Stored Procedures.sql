-- Get all authors
CREATE PROCEDURE GetAllAuthors
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Authors;
END;

GO

-- Get author by Id
CREATE PROCEDURE GetAuthorById
    @AuthorId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Authors WHERE AuthorId = @AuthorId;
END;
