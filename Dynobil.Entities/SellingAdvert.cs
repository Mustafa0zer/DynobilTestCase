using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.Entities;

public class SellingAdvert : EntityBase
{
    public int Year { get; set; }
    public double SellingPrice { get; set; }
    public int KmDriven { get; set; }
    public string Fuel { get; set; }
    public string Transmission { get; set; }
    public string Engine { get; set; }
    public string Power { get; set; }
    public int Seats { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public int ModelId { get; set; }
    public CarModel Model { get; set; }
}

public class AdvertWrapper
{
    public List<SellingAdvert> data { get; set; }
}