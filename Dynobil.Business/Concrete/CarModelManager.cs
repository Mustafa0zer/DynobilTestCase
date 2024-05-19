using Dynobil.Business.Abtraction;
using Dynobil.DataAccess.Abstract;
using Dynobil.DataAccess.Concrete;
using Dynobil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dynobil.Business.Concrete
{
    public class CarModelManager : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;
        private readonly string path = @"Uploads\car_brands.json";

        public CarModelManager(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }
        public string AddCarModel(CarModel model)
        {
            try
            {
                if (model != null)
                {
                    _carModelRepository.Add(model);

                }
                return "marka bilgisi eksik veya yanlış";
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        public bool AddRangeCarModel(ICollection<CarModel> CarModels)
        {
            try
            {
                if (CarModels != null)
                {
                    _carModelRepository.AddRange(CarModels);

                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public string DeleteCarModel(int id)
        {
            try
            {
                var CarModel = _carModelRepository.Get(x => x.Id == id);
                _carModelRepository.Delete(CarModel);
                return "Silme işlemi başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "silme işlemi sırasında bir hata oluştu. ";
            }

        }

        public ICollection<CarModel> GetAll()
        {
            try
            {
                var models = _carModelRepository.GetAll().ToList();
                if (models != null && models.Count != 0)
                    return models;
                else
                    return new List<CarModel>();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return new List<CarModel>();
            }
        }

        public async void ModelUpload()
        {
            

            var jsonData = File.ReadAllText(".\\Uploads\\car_models.json");
            var modelList = JsonSerializer.Deserialize<ModelWapper>(jsonData);
            if (modelList != null)
            {
                _carModelRepository.AddRange(modelList.data);
            }

        }

        public string UpdateCarModel(CarModel model)
        {
            try
            {
                if (model != null)
                {
                    var CarModel = _carModelRepository.Update(model);
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
