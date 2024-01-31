namespace Library.Domain.Entities
{
    public class BookCover
    {
        public BookCover()
        {
        }
        public int BookId { get; set; }
        public string CoverBase64 { get; set; }
    }
}
