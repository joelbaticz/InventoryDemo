using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Demo.Models;
using Demo.ViewModels;
using Demo.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        //The argument needs to match what you send from view
        public IActionResult Create(int id)
        {
            CreateProductViewModel vm = new CreateProductViewModel();

            vm.CategoryId = id;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //map
                Product prod = new Product
                {
                    CategoryId = vm.CategoryId,
                    Name = vm.Name,
                    Details = vm.Details,
                    Price = vm.Price
                };

                //save to db
                _productRepo.Create(prod);

                //go home/display/catid
                return RedirectToAction("Display", "Home", new { id = vm.CategoryId });


            }

            //not valid stay on the same view with the data
            return View(vm);
        }


    }
}
