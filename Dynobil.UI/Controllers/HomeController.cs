using Dynobil.Business.Abtraction;
using Dynobil.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dynobil.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarBrandService _brandService;
        private readonly ICarModelService _modelService;
        private readonly ISellingAdvertService _advertService;


        public HomeController(ICarBrandService brandService, ICarModelService modelService, ISellingAdvertService advertService)
        {
            _brandService = brandService;
            _modelService = modelService;
            _advertService = advertService;
        }

        public IActionResult Index()
        {
            DashBoardVM dashboardVM = new DashBoardVM();
            dashboardVM.ModelCount = _modelService.GetAll().ToList().Count;
            dashboardVM.BrandCount = _brandService.GetAll().ToList().Count;
            dashboardVM.AdvertCount = _advertService.GetAll().ToList().Count;
            if (dashboardVM.BrandCount == 0)
            {
                _brandService.BrandUpload();
            }
            if (dashboardVM.ModelCount == 0)
            {
                _modelService.ModelUpload();
            }
            if (dashboardVM.AdvertCount == 0)
            {
                _advertService.UploadAdverts();
            }

            return View(dashboardVM);
        }

    }
}
