using Dynobil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.Business.Abtraction
{
    public interface ICarBrandService
    {
        ICollection<CarBrand> GetAll();
        string AddCarBrand(CarBrand brand);
        string UpdateCarBrand(CarBrand brand);
        string DeleteCarBrand(int id);
        bool AddRangeCarBrand(ICollection<CarBrand> CarBrands);
        void BrandUpload();
    }
}
