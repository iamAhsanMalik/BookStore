using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly IMapper _mapper;

        public LanguageRepository(BookStoreContext context, IMapper mapper)
        {
            _bookStoreContext = context;
            _mapper = mapper;
        }

        public async Task<List<LanguageViewModel>> GetAllLanguages()
        {
            var result = await _bookStoreContext.Languages.ToListAsync();
            var languages = _mapper.Map<List<LanguageViewModel>>(result);
            return languages;
        }
        public async Task<int> AddNewLanguage(LanguageViewModel languageModel)
        {
            var newLanguage = _mapper.Map<Languages>(languageModel);
            await _bookStoreContext.Languages.AddAsync(newLanguage);
            await _bookStoreContext.SaveChangesAsync();
            return newLanguage.Language_Id;
        }

        public async Task<LanguageViewModel> GetLanguage(int id)
        {
            var result = await _bookStoreContext.Languages.FindAsync(id);
            var language = _mapper.Map<LanguageViewModel>(result);
            return language;
        }
    }
}
