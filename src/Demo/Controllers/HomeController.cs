using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Demo.Services;
using Demo.Models;
using Demo.ViewModels;



// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository _catRepo;
        private IProductRepository _productRepo;

        public HomeController(ICategoryRepository catRepo, IProductRepository productRepo)
        {
            _catRepo = catRepo;
            _productRepo = productRepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //Create the vm
            DisplayAllCategoriesViewModel vm = new DisplayAllCategoriesViewModel()
            {
                Categories = _catRepo.GetAll()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //CreateCategoryViewModel vm = new CreateCategoryViewModel();

            //return View(vm);
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //map vm to m
                Category cat = new Category
                {
                    Name = vm.Name,
                    Description = vm.Description
                };

                //save to DB
                
                _catRepo.Create(cat);

                //go home index
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Display(int id)
        {


            //Get cat by id
            Category cat = _catRepo.GetSingle(c => c.CategoryId == id);


            //get all product by cat id
            IEnumerable<Product> theProducts = _productRepo.Query(p => p.CategoryId == id);

            //create the vm
            DisplayCategoryViewModel vm = new DisplayCategoryViewModel();

            vm.CatId = cat.CategoryId;
            vm.CatName = cat.Name;
            vm.Description = cat.Description;
            vm.CatProducts = theProducts;

            //pass the vm to the view
            return View(vm);


            
        }




    }

}