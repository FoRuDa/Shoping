using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        public string Message;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string message)
        {
             Message = message;
        }
    }
}
