using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.Entities;

public class CarModel : EntityBase
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public CarBrand Brand { get; set; }
}

public class ModelWapper
{
    public List<CarModel> data { get; set; }

}
