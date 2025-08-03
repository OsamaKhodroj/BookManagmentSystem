using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Enums;

namespace LibrarySystem.Models.Interfaces
{
    public interface IBook
    {
        public OpStatusEnum Add(Book book);
        public OpStatusEnum Update(Book book);
        public OpStatusEnum Delete(int id);
        public Book GetById(int id);
        public List<Book> GetAll();
    }
}
