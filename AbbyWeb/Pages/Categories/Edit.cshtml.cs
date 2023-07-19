using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AbbyWeb.Pages.Categories
{
	[BindProperties] //this will help if we have 2 or more post methods.
	public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {   
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The name and display order cannot be same");
            }
            if(ModelState.IsValid)
            {
				 _db.Category.Update(Category);
				await _db.SaveChangesAsync();
				return RedirectToPage("Index");
			}
           return Page();
        }
    }
}
