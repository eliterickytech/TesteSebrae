using Microsoft.AspNetCore.Mvc;

namespace TesteSebrae.UI.Controllers
{
    public class ContaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7194/");
                var result = await client.GetAsync("api/Conta");

                if (result.IsSuccessStatusCode)
                {
                    return View(result);
                }
            }
            return View();
        }
    }
}
