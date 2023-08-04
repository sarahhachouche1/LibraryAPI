namespace LibraryManagementSystemBackend.Core.Entities
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? BookImage { get; set; }
        public int? TotalCopies { get; set; }
        public int? AvailableCopies { get; set; }
        public int LibrarianID { get; set; }
        public int AuthorID { get; set; }
        public int LanguageID { get; set; }
        public int GenereID { get; set; }
    }

}
