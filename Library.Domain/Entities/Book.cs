namespace Library.Domain.Entities
{
    public class Book: BaseEntity
    {
        public int BookId { get; set; }
        public string BookInfo { get; set; }
        public DateTime LastModified { get; set; }
    }
}
