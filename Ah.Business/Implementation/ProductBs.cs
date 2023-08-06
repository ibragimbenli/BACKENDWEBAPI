using Ah.Business.Interface;
using Ah.DataAccess.Interfaces;
using Ah.Model.Dtos.Product;
using Ah.Model.Entities;
using AutoMapper;
using CommonTypesLayer.Model;
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
        private readonly IMapper _mapper;

        public ProductBs(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var product = _repo.GetById(id);

            _repo.Delete(product);
        }

        public ProductGetDto GetById(int productId, params string[] includeList)
        {
            var product = _repo.GetById(productId, includeList);

            if (product != null)
            {
                var dto = _mapper.Map<ProductGetDto>(product);
                return dto;
            }
            return null;
        }

        // readonly ya buraya tanımlandığı anda setleme yapacağız ya da constructor içinde setleeyceğiz. Eğer buraya bunu koymazsak isteyen herkes her yerde _repo'yu setler ve buda bizim işimize gelmez. 
        public List<ProductGetDto> GetProducts(params string[] includeList)
        {
            //Loglama
            //Authenticaiton

            //VeriTabanından getAll ile ürünleri getirecek....
            //return _repo.GetAll(null,includeList);
            var products = _repo.GetAll(includeList: includeList);
            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<ProductGetDto>>(products);

                return productList;
            }

            return null; ;

            //Loglama
            //Validation
            //Authenticaiton
        }

        public List<ProductGetDto> GetProductsByPrice(decimal min, decimal max, params string[] includeList)
        {
            //Loglama
            //Authenticaiton

            var products = _repo.GetByPriceRange(min, max, includeList);
            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<ProductGetDto>>(products);
                return productList;
            }

            return null;
            //Loglama
            //Validation
            //Authenticaiton
        }

        public List<ProductGetDto> GetProductsByStock(short min, short max, params string[] includeList)
        {
            //Loglama
            //Authenticaiton

            var products = _repo.GetProductsByStock(min, max, includeList);

            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<ProductGetDto>>(products);
                return productList;
            }

            return null;
            //Loglama
            //Validation
            //Authenticaiton
        }

        public Product Insert(ProductPostDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            return _repo.Insert(product);
        }

        public void Update(ProductPutDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _repo.Update(product);
        }
    }
}
