
using Dynobil.Business.Abtraction;
using Dynobil.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dynobil.UI.Controllers
{
    public class AdvertController : Controller
    {
        private readonly ISellingAdvertService _advertService;
        private readonly ICarBrandService _brandService;
        private readonly ICarModelService _modelService;

        public AdvertController(ISellingAdvertService advertService, ICarBrandService brandService, ICarModelService modelService)
        {
            _advertService = advertService;
            _brandService = brandService;
            _modelService = modelService;
        }

        public IActionResult Index()
        {
            var adverts = _advertService.GetAll();
            
            return View(adverts);
        }
        [HttpGet]
        public IActionResult AddNewAdvert()
        {
            var brands = _brandService.GetAll();
            var models = _modelService.GetAll();
            ViewBag.BrandList = new SelectList(brands, "Id", "Name");
            ViewBag.ModelList = new SelectList(Enumerable.Empty<SelectListItem>());
            return View(new SellingAdvert());
        }
        [HttpPost]
        public IActionResult AddNewAdvert(SellingAdvert advert)
        {
            var result = _advertService.AddSellingAdvert(advert);
            TempData["ResultMessage"] = result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetModelsByBrandId(int brandId)
        {
            var models = _modelService.GetAll().Where(m => m.BrandId == brandId).ToList();
            return Json(models);
        }
        [HttpGet]
        public IActionResult UpdateAdvert(int id)
        {
            var brands = _brandService.GetAll();
            var models = _modelService.GetAll();
            ViewBag.BrandList = new SelectList(brands, "Id", "Name");
            ViewBag.ModelList = new SelectList(Enumerable.Empty<SelectListItem>());
            var advert = _advertService.Get(id);
            return View(advert);

        }
        [HttpPost]
        public IActionResult UpdateAdvert(SellingAdvert advert)
        {
           var result =  _advertService.UpdateSellingAdvert(advert);
            TempData["ResultMessage"] = result;
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult DetailAdvert(int id)
        {
            var brands = _brandService.GetAll();
            var models = _modelService.GetAll();
            ViewBag.BrandList = new SelectList(brands, "Id", "Name");
            ViewBag.ModelList = new SelectList(Enumerable.Empty<SelectListItem>());
            var advert = _advertService.Get(id);
            return View(advert);

        }
        [HttpPost]
        public IActionResult DetailAdvert(SellingAdvert advert)
        {
            var result = _advertService.UpdateSellingAdvert(advert);
            TempData["ResultMessage"] = result;
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult DeleteAdvert(int id) 
        {
            var result = _advertService.DeleteSellingAdvert(id);
            TempData["ResultMessage"] = result;
            return RedirectToAction("Index");
        }
    }
}
