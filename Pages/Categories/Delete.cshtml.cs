using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories;

[BindProperties]
public class Delete : PageModel
{
    private readonly ApplicationDbContext _db;

    public Category Category { get; set; }

    public Delete(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet(int Id)
    {
        Category = _db.Categories.Find(Id);
    }
    public async Task<IActionResult> OnPost()
    {
        var categoryFromDb = _db.Categories.Find(Category.Id);
        if (categoryFromDb != null)
        {
            _db.Categories.Remove(categoryFromDb);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");

        }

        return Page();
    }
}