using BookStore.Models;
using BookStore.ViewModel;

namespace BookStore.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookViewModel book);
        Task<List<BookViewModel>> GetAllBooks();
        Task<BookViewModel> GetBook(int id);
        Task<List<BookViewModel>> TopBooks(int count);
    }
}