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

        public Product GetById(int productId, params string[] includeList)
        {
            return _repo.GetById(productId);
        }

        // readonly ya buraya tanımlandığı anda setleme yapacağız ya da constructor içinde setleeyceğiz. Eğer buraya bunu koymazsak isteyen herkes her yerde _repo'yu setler ve buda bizim işimize gelmez. 
        public List<Product> GetProducts(params string[] includeList)
        {
            //Loglama
            //Validation
            //Authenticaiton

            //VeriTabanından getAll ile ürünleri getirecek....
            //return _repo.GetAll(null,includeList);
            return _repo.GetAll(includeList: includeList);

            //Loglama
            //Validation
            //Authenticaiton
        }

        public List<Product> GetProductsByPrice(decimal min, decimal max, params string[] includeList)
        {
            //Loglama
            //Validation
            //Authenticaiton

            //VeriTabanından getAll ile ürünleri getirecek....
            return _repo.GetByPriceRange(min, max, includeList);
            //Loglama
            //Validation
            //Authenticaiton
        }

        public List<Product> GetProductsByStock(short min, short max, params string[] includeList)
        {
            //Loglama
            //Validation
            //Authenticaiton

            //VeriTabanından getAll ile ürünleri getirecek....
            var result = _repo.GetProductsByStock(min, max, includeList);
            return result;
            //Loglama
            //Validation
            //Authenticaiton
        }

        public void Insert(Product entity)
        {
           _repo.Insert(entity);
        }
    }
}
