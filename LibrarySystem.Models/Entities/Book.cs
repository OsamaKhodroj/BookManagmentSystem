using LibrarySystem.Models.Enums;

namespace LibrarySystem.Models.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public BookStatusEnum BookStatus { get; set; }
    }
}
