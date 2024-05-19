using Dynobil.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynobil.Business.Abtraction
{
    public interface ISellingAdvertService
    {
        ICollection<SellingAdvert> GetAll();
        SellingAdvert Get(int  id); 
        string AddSellingAdvert(SellingAdvert advert);
        string UpdateSellingAdvert(SellingAdvert advert);
        string DeleteSellingAdvert(int id);
        void UploadAdverts();
    }
}
