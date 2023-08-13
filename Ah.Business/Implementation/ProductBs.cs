using Ah.Business.CustomExceptions;
using Ah.Business.Interface;
using Ah.DataAccess.Interfaces;
using Ah.Model.Dtos.Product;
using Ah.Model.Entities;
using AutoMapper;
using CommonTypesLayer.Model;
using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
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

        public ApiResponse<NoData> Delete(int id)
        {

            var product = _repo.GetById(id);

            _repo.Delete(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }


        public ApiResponse<ProductGetDto> GetById(int productId, params string[] includeList)
        {
            var product = _repo.GetById(productId, includeList);

            if (product != null)
            {
                var dto = _mapper.Map<ProductGetDto>(product);
                return ApiResponse<ProductGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");

        }

        // readonly ya buraya tanımlandığı anda setleme yapacağız ya da constructor içinde setleeyceğiz. Eğer buraya bunu koymazsak isteyen herkes her yerde _repo'yu setler ve buda bizim işimize gelmez. 
        public ApiResponse<List<ProductGetDto>> GetProducts(params string[] includeList)
        {
            //Loglama
            //Authenticaiton

            var products = _repo.GetAll(includeList: includeList);
            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<ProductGetDto>>(products);
                var response = ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, productList);

                return response;
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");

            //Loglama
            //Authenticaiton
        }

        public ApiResponse<List<ProductGetDto>> GetProductsByPrice(decimal min, decimal max, params string[] includeList)
        {
            //Loglama
            //Authenticaiton
            if (min > max)
                throw new BadRequestException("Min Değeri Max değerinden küçük olamaz!");
            if (min == max)
                throw new BadRequestException("Min değeri ile eşit olamaz");
            if (min < 0 || max < 0)
                throw new BadRequestException("min veya max değerinleri negatif olamaz!");
            // tüm validasyon parametrelerini burada işleyebilirisiniz...

            var products = _repo.GetByPriceRange(min, max, includeList);

            if (products != null || products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new BadRequestException("Ürün Yok");
            //Loglama
            //Authenticaiton
        }

        public ApiResponse<List<ProductGetDto>> GetProductsByStock(short min, short max, params string[] includeList)
        {
            //Loglama
            //Authenticaiton


            if (min > max)
                throw new BadRequestException("Min Değeri Max değerinden küçük olamaz!");

            if (min < 0 || max < 0)
                throw new BadRequestException("min veya max değerinleri negatif olamaz!");
            // tüm validasyon parametrelerini burada işleyebilirisiniz...

            var products = _repo.GetProductsByStock(min, max, includeList);

            if (products != null || products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Ürün Yok");

            //Loglama
            //Authenticaiton
        }

        public ApiResponse<Product> Insert(ProductPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.UnitPrice <= 0)
                throw new BadRequestException("Kaydedilecek Ürün fiyatı 0'dan büyük olmalıdır.");
            if (dto.UnitsInStock <= 0)
                throw new BadRequestException("Kaydedilecek Ürün adedi 0'dan büyük olmalıdır.");
            // validasyonlar....
            var product = _mapper.Map<Product>(dto);
            var insertedProduct = _repo.Insert(product);
            return ApiResponse<Product>.Success(StatusCodes.Status200OK, insertedProduct);
        }

        public ApiResponse<NoData> Update(ProductPutDto dto)
        {

            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.UnitPrice <= 0)
                throw new BadRequestException("Kaydedilecek Ürün fiyatı 0'dan büyük olmalıdır.");
            if (dto.UnitsInStock <= 0)
                throw new BadRequestException("Kaydedilecek Ürün adedi 0'dan büyük olmalıdır.");
            //validasyonlar....
            var product = _mapper.Map<Product>(dto);
            _repo.Update(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }
    }
}
