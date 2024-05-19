using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.Entities;

public class CarBrand:EntityBase
{
    public string Name { get; set; }
}

public class BrandWrapper
{
    public List<CarBrand> data { get; set; }
}
