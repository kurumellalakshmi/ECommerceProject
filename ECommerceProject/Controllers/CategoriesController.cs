using ECommerceProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProject.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public CategoriesController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: Categories
        public ActionResult Index()
        {
            var img = dbContext.products.ToList();
            return View(img);
        }
        [HttpGet]
        [Authorize(Roles = "Sales_Manager")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            product.ImagePath = "~/Products/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Products/"), fileName);
            ImageFile.SaveAs(fileName);

            dbContext.products.Add(product);
            dbContext.SaveChanges();
            return View("Index", "Categories");
        }

        [HttpGet]
        public ActionResult Mobile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mobile(Mobile mobile, HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            mobile.ImagePath = "~/Mobiles/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Mobiles/"), fileName);
            ImageFile.SaveAs(fileName);

            dbContext.mobiles.Add(mobile);
            dbContext.SaveChanges();
            return View("DisplayMobiles");
        }

        public ActionResult DisplayMobiles()
        {
            var img = dbContext.mobiles.ToList();
            return View(img);
        }

        public ActionResult DisplayLaptops()
        {
            var img = dbContext.laptops.ToList();
            return View(img);
        }

        [HttpGet]
        public ActionResult Laptop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Laptop(Laptop laptop, HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            laptop.ImagePath = "~/Laptops/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Laptops/"), fileName);
            ImageFile.SaveAs(fileName);

            dbContext.laptops.Add(laptop);
            dbContext.SaveChanges();
            return View("DisplayLaptops");
        }

        public ActionResult DisplayFurniture()
        {
            var img = dbContext.furnitures.ToList();
            return View(img);
        }

        [HttpGet]
        public ActionResult Furniture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Furniture(Furniture furniture, HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            furniture.ImagePath = "~/Furniture/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Furniture/"), fileName);
            ImageFile.SaveAs(fileName);

            dbContext.furnitures.Add(furniture);
            dbContext.SaveChanges();
            return View("DisplayFurniture");
        }

        public ActionResult DisplayBeauty()
        {
            var img = dbContext.beauties.ToList();
            return View(img);
        }

        [HttpGet]
        public ActionResult Beauty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Beauty(Beauty beauty, HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            beauty.ImagePath = "~/Beauty/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Beauty/"), fileName);
            ImageFile.SaveAs(fileName);

            dbContext.beauties.Add(beauty);
            dbContext.SaveChanges();
            return View("DisplayBeauty");
        }

        public ActionResult Search(string searching)
        {
            return View(dbContext.products.Where(x => x.ProductName.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Buy()
        {
            return View();
        }
    }
}