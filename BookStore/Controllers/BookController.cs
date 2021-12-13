using BookStore.Models;
using BookStore.Repository;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> GetAllBooks()
        {
            var allBooks = await _bookRepository.GetAllBooks();
            return View(allBooks);
        }
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookRepository.GetBook(id);
            return View(book);
        }

        [HttpGet]
        [Authorize]

        public IActionResult AddNewBook(int bookId = 0, bool isSuccess = false)
        {
            //ViewBag.languages = await BooksLanguages();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;

            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewBook(BookViewModel bookModel)
        {
            //ViewBag.languages = await BooksLanguages();
            if (ModelState.IsValid)
            {
                // Book Conver Image Upload
                if (bookModel.CoverPhoto != null)
                {
                    string imageFolder = @"images\books\cover\";
                    bookModel.ImageURL = await FileUploader(imageFolder, bookModel.CoverPhoto);
                }

                // Book Gallery Images Upload
                if (bookModel.BookGallery != null)
                {
                    string galleryFolder = @"images\books\gallery\";

                    bookModel.Gallery = new List<GalleryViewModel>();
                    foreach (var item in bookModel.BookGallery)
                    {
                        var gallery = new GalleryViewModel() {
                            Name = item.FileName,
                            URL = await FileUploader(galleryFolder, item)
                        };
                        bookModel.Gallery.Add(gallery);
                    }
                }
                // Book PDF Upload
                if (bookModel.PDFBook != null)
                {
                    string pdfFolder = @"books\pdf\";
                    bookModel.PDFBookURL = await FileUploader(pdfFolder, bookModel.PDFBook);
                }

                var result = await _bookRepository.AddNewBook(bookModel);

                if (result > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { bookId = result, isSuccess = true });
                }
            }
            return View();
        }

        private async Task<string> FileUploader(string folder, IFormFile file)
        {
            //Book Gallery Image Upload

            var folderPath = @$"{_webHostEnvironment.WebRootPath}\{folder}";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath = folder + Guid.NewGuid().ToString() + file.FileName;
            string fileURL = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
            await file.CopyToAsync(new FileStream(fileURL, FileMode.Create));
            return @$"\{filePath}";

        }

        private async Task<SelectList> BooksLanguages()
        {
            var data = new SelectList(await _languageRepository.GetAllLanguages(), "Language_Id", "Name");
            return data;
        }
    }
}