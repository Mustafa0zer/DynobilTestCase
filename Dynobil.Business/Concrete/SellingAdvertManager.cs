using Dynobil.Business.Abtraction;
using Dynobil.DataAccess.Abstract;
using Dynobil.DataAccess.Concrete;
using Dynobil.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dynobil.Business.Concrete
{
    public class SellingAdvertManager : ISellingAdvertService
    {
        private readonly ISellingAdvertRepository _sellingAdvertRepository;

        public SellingAdvertManager(ISellingAdvertRepository sellingAdvertRepository)
        {
            _sellingAdvertRepository = sellingAdvertRepository;
        }

        public string AddSellingAdvert(SellingAdvert advert)
        {
            try
            {
                if (advert != null)
                {
                    var advertResult = _sellingAdvertRepository.Add(advert);
                    return "ekleme  işlemi başarılı";
                }
                return "Ekleme işlemi sırasında bir hata meydana geldi";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public string DeleteSellingAdvert(int id)
        {
            try
            {
                var advert = _sellingAdvertRepository.Get(x => x.Id == id);
                _sellingAdvertRepository.Delete(advert);
                return "silme işlemi başarılı";
            }
            catch (Exception e)
            {

                return e.ToString();
            }
        }

        public SellingAdvert Get(int id)
        {
           var advert =  _sellingAdvertRepository.Get(x=>x.Id == id,include:x=>x.Include(c=>c.Model).ThenInclude(y=>y.Brand));
            return advert;
        }

        public ICollection<SellingAdvert> GetAll()
        {
            try
            {
                var adverts = _sellingAdvertRepository.GetAll(query =>
                                                              query.Include(ad=>ad.Model).ThenInclude(ad=>ad.Brand)
                                                              ).ToList();
                return adverts;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<SellingAdvert>();
            }
        }

        public string UpdateSellingAdvert(SellingAdvert advert)
        {
            try
            {
                if (advert != null)
                {
                    _sellingAdvertRepository.Update(advert);
                    return "Güncelleme işlemi başarılı";
                }
                return "güncelleme nesnesi bulunamadı.";
            }
            catch (Exception e)
            {

                return e.ToString();
            }
        }

        public void UploadAdverts()
        {
            var jsonData = File.ReadAllText(".\\Uploads\\advert-seed.json");
            var modelList = JsonSerializer.Deserialize<AdvertWrapper>(jsonData);
            _sellingAdvertRepository.AddRange(modelList.data);
        }
    }
}
