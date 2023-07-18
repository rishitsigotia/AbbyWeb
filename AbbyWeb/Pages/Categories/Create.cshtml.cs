using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AbbyWeb.Pages.Categories
{
	[BindProperties] //this will help if we have 2 or more post methods.
	public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
				await _db.Category.AddAsync(Category);
				await _db.SaveChangesAsync();
				return RedirectToPage("Index");
			}
           return Page();
        }
    }
}
