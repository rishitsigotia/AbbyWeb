using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AbbyWeb.Pages.Categories
{
	[BindProperties] //this will help if we have 2 or more post methods.
	public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {   
                var categoryFromdb = _db.Category.Find(Category.Id);
                if(categoryFromdb != null)
                {
                    _db.Category.Remove(categoryFromdb);
					await _db.SaveChangesAsync();
				    return RedirectToPage("Index");

			    }		
           return Page();
        }
    }
}
