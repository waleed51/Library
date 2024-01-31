CREATE VIEW dbo.BooksInfoJson
WITH SCHEMABINDING
AS
     SELECT 
        BookId,
        JSON_VALUE(BookInfo, '$.Author') AS Author,
        JSON_VALUE(BookInfo, '$.BookTitle') AS BookTitle,
        JSON_VALUE(BookInfo, '$.BookDescription') AS BookDescription,
        JSON_VALUE(BookInfo, '$.PublishDate') AS PublishDate,
        LastModified
    FROM dbo.Book;
GO

CREATE UNIQUE CLUSTERED INDEX cidx_BooksInfoJson ON dbo.BooksInfoJson(BookId);
CREATE INDEX idx_BooksInfoJson_Author ON dbo.BooksInfoJson(Author);
CREATE INDEX idx_BooksInfoJson_BookTitle ON dbo.BooksInfoJson(BookTitle);
CREATE INDEX idx_BooksInfoJson_BookDescription ON dbo.BooksInfoJson(BookDescription);
CREATE INDEX idx_BooksInfoJson_PublishDate ON dbo.BooksInfoJson(PublishDate);
CREATE INDEX idx_BooksInfoJson_LastModified ON dbo.BooksInfoJson(LastModified);
