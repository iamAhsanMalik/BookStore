using BookStore.Repository;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
        [HttpGet]
        public IActionResult AddNewLanguage(bool isSuccess = false, int language_Id = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.LanguageId = language_Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewLanguage(LanguageViewModel languageModel)
        {
            if (ModelState.IsValid)
            {
                var data = await _languageRepository.AddNewLanguage(languageModel);
                if (data > 0)
                {
                    return RedirectToAction(nameof(AddNewLanguage), new { isSuccess = true, language_Id = data });
                }
            }
            return View();
        }
        public async Task<IActionResult> GetAllLanguages()
        {
            var data = await _languageRepository.GetAllLanguages();
            return View(data);
        }
        public async Task<IActionResult> GetLanguage(int id)
        {
            var language = await _languageRepository.GetLanguage(id);
            return View(language);
        }

    }
}
