using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thrift.Data;
using Thrift.Models;
using Thrift.ViewModel;

namespace Thrift.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ThriftDbContext _context;
        public CategoryController(ThriftDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var data = _context.Categories.AsNoTracking().Select(x => new CategoryViewModel()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
            }).ToList();

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel vm)
        {


            _context.Categories.Add(new()
            {
                CategoryName = vm.CategoryName,
                Description = vm.Description,
            });

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _context.Categories.Where(x => x.CategoryId == id).Select(x => new CategoryViewModel()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description,
            }).First();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var categoryFromDb = _context.Categories.Find(vm.CategoryId);
                if (categoryFromDb != null)
                {
                    categoryFromDb.CategoryName = vm.CategoryName;
                    categoryFromDb.Description = vm.Description;
                    _context.Categories.Update(categoryFromDb);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {

                    return NotFound();
                }
            }
            else
            {
                return View(vm);
            }
        }
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            _=category != null ? _context.Categories.Remove(category) : null;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
