using Dynobil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.Business.Abtraction
{
    public interface ICarModelService
    {
        ICollection<CarModel> GetAll();
        string AddCarModel(CarModel model);
        string UpdateCarModel(CarModel model);
        string DeleteCarModel(int id);
        bool AddRangeCarModel(ICollection<CarModel> carModels);
        void ModelUpload();
    }
}
