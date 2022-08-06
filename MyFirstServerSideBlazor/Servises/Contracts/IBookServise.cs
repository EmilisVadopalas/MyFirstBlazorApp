using MyFirstServerSideBlazor.Structures.Books;

namespace MyFirstServerSideBlazor.Servises
{
    public interface IBookServise
    {
        public Task<List<Book>> SearchBooksByAuthor(string searchKeyWords);
    }

    public interface IEmailServise 
    {
        public Task SendMail(string[] emails, string subject, string message);
    }

}