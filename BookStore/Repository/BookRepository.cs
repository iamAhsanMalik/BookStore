using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _bookStoreContext = context;
            _mapper = mapper;
        }
        public async Task<int> AddNewBook(BookViewModel model)
        {
            var newBook = _mapper.Map<Books>(model);
            newBook.BookGallery = new List<BookGallery>();
            var gallery = model.Gallery;
            if (gallery != null)
            {
                foreach (var file in gallery)
                {
                    newBook.BookGallery.Add(new BookGallery() {
                        Name = file.Name,
                        URL = file.URL
                    });
                }
            }
            await _bookStoreContext.Books.AddAsync(newBook);
            await _bookStoreContext.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookViewModel>> GetAllBooks()
        {
            var result = await _bookStoreContext.Books.ToListAsync();
            var books = _mapper.Map<List<BookViewModel>>(result);
            return books;
        }

        public async Task<BookViewModel> GetBook(int id)
        {
            var result = await _bookStoreContext.Books.FindAsync(id);
            var language = await _bookStoreContext.Languages.FindAsync(id);
            var gallery = _bookStoreContext.BookGallery;
            var book = _mapper.Map<BookViewModel>(result);
            book.Gallery = await gallery.Where(x => x.Book_Id == id).Select(g => new GalleryViewModel() { Id = g.Id, Name = g.Name, URL = g.URL }).ToListAsync();

            book.Language = language?.Name;
            return book;

        }

        public async Task<List<BookViewModel>> TopBooks(int count)
        {
            var result = await _bookStoreContext.Books.Take(count).ToListAsync();
            var books = _mapper.Map<List<BookViewModel>>(result);
            return books;
        }

    }
}
