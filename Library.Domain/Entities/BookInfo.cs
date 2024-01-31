namespace Library.Domain.Entities
{
    public class BookInfo
    {
        public string Author { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string CoverBase64 { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
