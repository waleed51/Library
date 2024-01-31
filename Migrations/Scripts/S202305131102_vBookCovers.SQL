CREATE VIEW dbo.BookCovers
WITH SCHEMABINDING
AS
SELECT 
      BookId,
      Cover.CoverBase64
    FROM dbo.Book
    CROSS APPLY OPENJSON(BookInfo)
WITH (CoverBase64 NVARCHAR(MAX) '$.CoverBase64') AS Cover;
GO