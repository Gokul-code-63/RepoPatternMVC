using RepositoryPatternMVC.Models;
using RepositoryPatternMVC.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryPatternMVC.Controllers
{
    public class HomeController : Controller
    {
        //declare interface type variable in controller
        private IProductRepository _productRepository;

        public HomeController()
        {
            this._productRepository = new ProductRepository(new RepoPatternTestDbEntities());
        }

        //dependency injection using ctor by passing obj of type interface 
        public HomeController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        //generic methods
        public ActionResult Index()
        {
            return View(_productRepository.GetProducts());
        }
        public ActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            _productRepository.InsertProduct(product);
            _productRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int Id)
        {
            return View(_productRepository.GetProductById(Id));
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            _productRepository.UpdateProduct(product);
            _productRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            _productRepository.DeleteProduct(Id);
            _productRepository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}