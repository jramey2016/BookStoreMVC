using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //Get action method
        public IActionResult Create()
        {
            return View();
        }

        //Post action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.DisplayOrder.ToString());
            string Disp = obj.DisplayOrder.ToString();
            Console.WriteLine(Disp);

            if (obj.Name == Disp)
            {
                
                ModelState.AddModelError("CustomError", "Fields are the same value");
                
            }
           
            if (ModelState.IsValid)
            {
                
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
