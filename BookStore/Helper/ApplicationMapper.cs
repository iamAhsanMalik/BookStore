using AutoMapper;
using BookStore.Models;
using BookStore.ViewModel;
using System.Linq.Expressions;

namespace BookStore.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookViewModel>().ReverseMap();
            CreateMap<BookGallery, GalleryViewModel>().ReverseMap();
            CreateMap<BookGallery, IFormFile>().ReverseMap();
            CreateMap<Languages, LanguageViewModel>().ReverseMap();

        }
    }
}
