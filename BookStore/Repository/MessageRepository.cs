using BookStore.Models;
using Microsoft.Extensions.Options;

namespace BookStore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<NewBookAlertConfig> _options;

        public MessageRepository(IOptionsMonitor<NewBookAlertConfig> options)
        {
            _options = options;
        }
        public string GetName()
        {
            var data = _options.CurrentValue.BookName;
            if (data == null) return string.Empty;
            return data;
        }
    }
}
