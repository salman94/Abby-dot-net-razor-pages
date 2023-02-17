using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories;

[BindProperties]
public class Create : PageModel
{
    private readonly ApplicationDbContext _db;
    public Category Category { get; set; }

    public Create(ApplicationDbContext db)
    {
        _db = db;
    }

    
    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            TempData["error"] = "Invalid input";
        }
        if (ModelState.IsValid)
        {
            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category added successfully";
            return RedirectToPage("Index");  
        }

        return Page();
    }
}