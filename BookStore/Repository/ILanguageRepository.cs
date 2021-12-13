using BookStore.ViewModel;

namespace BookStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageViewModel>> GetAllLanguages();
        Task<int> AddNewLanguage(LanguageViewModel languageModel);
        Task<LanguageViewModel> GetLanguage(int languageId);
    }
}
