using Dynobil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.DataAccess.Abstract
{
    public interface ICarModelRepository:IRepository<CarModel,int>
    {
    }
}
