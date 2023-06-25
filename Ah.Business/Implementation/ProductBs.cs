using Ah.Business.Interface;
using Ah.DataAccess.Interfaces;
using Ah.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ah.Business.Implementation
{
    public class ProductBs : IProductBs
    {
        private readonly IProductRepository _repo;

        public ProductBs(IProductRepository repo)
        {
            _repo = repo;
        }

        // readonly ya buraya tanımlandığı anda setleme yapacağız ya da constructor içinde setleeyceğiz. Eğer buraya bunu koymazsak isteyen herkes her yerde _repo'yu setler ve buda bizim işimize gelmez. 
        public List<Product> GetProducts()
        {
            //Loglama
            //Validation
            //Authenticaiton

            //VeriTabanından getAll ile ürünleri getirecek....
            
            //Loglama
            //Validation
            //Authenticaiton

            return _repo.GetAll();
        }
    }
}
