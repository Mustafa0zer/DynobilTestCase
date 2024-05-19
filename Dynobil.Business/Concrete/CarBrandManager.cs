using Dynobil.Business.Abtraction;
using Dynobil.DataAccess.Abstract;
using Dynobil.Entities;
using System.Text.Json;

namespace Dynobil.Business.Concrete
{
    public class CarBrandManager : ICarBrandService
    {
        private readonly ICarBrandRepository _carBrandRepository;

        public CarBrandManager(ICarBrandRepository carBrandRepository)
        {
            _carBrandRepository = carBrandRepository;
        }

        public string AddCarBrand(CarBrand brand)
        {
            try
            {
                if (brand != null)
                {
                    _carBrandRepository.Add(brand);

                }
                return "marka bilgisi eksik veya yanlış";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        public bool AddRangeCarBrand(ICollection<CarBrand> carBrands)
        {
            try
            {
                if (carBrands != null)
                {
                    _carBrandRepository.AddRange(carBrands);

                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public void BrandUpload()
        {
            var jsonData = File.ReadAllText(".\\Uploads\\car_brands.json");
            var modelList = JsonSerializer.Deserialize<BrandWrapper>(jsonData);
            _carBrandRepository.AddRange(modelList.data);

        }

        public string DeleteCarBrand(int id)
        {
            try
            {
                var carBrand = _carBrandRepository.Get(x => x.Id == id);
                _carBrandRepository.Delete(carBrand);
                return "Silme işlemi başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "silme işlemi sırasında bir hata oluştu. ";
            }

        }

        public ICollection<CarBrand> GetAll()
        {
            try
            {
                var brands = _carBrandRepository.GetAll().ToList();
                if (brands != null && brands.Count != 0)
                    return brands;
                else
                    return new List<CarBrand>();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return new List<CarBrand>();
            }
        }

        public string UpdateCarBrand(CarBrand brand)
        {
            try
            {
                if (brand != null)
                {
                    var carBrand = _carBrandRepository.Update(brand);
                    return "güncelleme işlemi başarılı";
                }
                return "güncelleme işlemi sırasında bir sorun oluştu";

            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }
    }
}
