using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public IEnumerable<Category> Categories;

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Categories = _db.Categories;
    }
}