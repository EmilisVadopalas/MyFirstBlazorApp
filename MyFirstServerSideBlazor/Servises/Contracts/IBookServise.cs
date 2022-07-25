using MyFirstServerSideBlazor.Structures.Books;

namespace MyFirstServerSideBlazor.Servises
{
    public interface IBookServise
    {
        public Task<List<Book>> SearchBooksByAuthor(string searchKeyWords);
    }
}