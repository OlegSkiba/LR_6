using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public List<Product> Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product { Name = "Pizza", Quantity = 0 },
                new Product { Name = "Drink", Quantity = 0 },
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // якщо дан≥ не Ї д≥йсними, повернути ту ж стор≥нку з помилками
                return Page();
            }

            if (User.Age > 16)
            {
                // якщо користувачу б≥льше 16 рок≥в, встановлюЇмо значенн€ флагу в true
                TempData["Over16"] = true;
            }
            else
            {
                // якщо користувачу менше 16 рок≥в, встановлюЇмо значенн€ флагу в false
                TempData["Over16"] = false;
            }

            // ѕеренаправленн€ на ту ж стор≥нку дл€ в≥дображенн€ ≥нших форм або результат≥в
            return RedirectToPage();
        }

        public IActionResult OnPostOrder()
        {
            if (!ModelState.IsValid)
            {
                // якщо дан≥ не Ї д≥йсними, повернути ту ж стор≥нку з помилками
                return Page();
            }
            return Page();
        }
    }
}
