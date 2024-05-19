using Dynobil.DataAccess.Abstract;
using Dynobil.DataAccess.Concrete.Context;
using Dynobil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.DataAccess.Concrete
{
    public class CarModelRepository : EfRepositoryBase<CarModel, int, DynobilContext>, ICarModelRepository
    {
        public CarModelRepository(DynobilContext context) : base(context)
        {
        }
    }
}
