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

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {

            var product = await _repo.GetByIdAsync(id);

            await _repo.DeleteAsync(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }


        public async Task<ApiResponse<ProductGetDto>> GetByIdAsync(int productId, params string[] includeList)
        {
            var product = await _repo.GetByIdAsync(productId, includeList);

            if (product != null)
            {
                var dto = _mapper.Map<ProductGetDto>(product);
                return ApiResponse<ProductGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("Aradığınız Ürün Bulunamadı.");

        }

        // readonly ya buraya tanımlandığı anda setleme yapacağız ya da constructor içinde setleeyceğiz. Eğer buraya bunu koymazsak isteyen herkes her yerde _repo'yu setler ve buda bizim işimize gelmez. 
        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList)
        {
            //Loglama
            //Authenticaiton

            var products = await _repo.GetAllAsync(includeList: includeList);
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

        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsByPriceAsync(decimal min, decimal max, params string[] includeList)
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

            var products = await _repo.GetByPriceRangeAsync(min, max, includeList);

            if (products != null || products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new BadRequestException("Ürün Yok");
            //Loglama
            //Authenticaiton
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsByStockAsync(short min, short max, params string[] includeList)
        {
            //Loglama
            //Authenticaiton


            if (min > max)
                throw new BadRequestException("Min Değeri Max değerinden küçük olamaz!");

            if (min < 0 || max < 0)
                throw new BadRequestException("min veya max değerinleri negatif olamaz!");
            // tüm validasyon parametrelerini burada işleyebilirisiniz...

            var products = await _repo.GetProductsByStockAsync(min, max, includeList);

            if (products != null || products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Ürün Yok");

            //Loglama
            //Authenticaiton
        }

        public async Task<ApiResponse<Product>> InsertAsync(ProductPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.UnitPrice <= 0)
                throw new BadRequestException("Kaydedilecek Ürün fiyatı 0'dan büyük olmalıdır.");
            if (dto.UnitsInStock <= 0)
                throw new BadRequestException("Kaydedilecek Ürün adedi 0'dan büyük olmalıdır.");
            // validasyonlar....
            var product = _mapper.Map<Product>(dto);
            var insertedProduct = await _repo.InsertAsync(product);
            return ApiResponse<Product>.Success(StatusCodes.Status200OK, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto dto)
        {

            if (dto == null)
                throw new BadRequestException("Kaydedecek Ürün yok");
            if (dto.UnitPrice <= 0)
                throw new BadRequestException("Kaydedilecek Ürün fiyatı 0'dan büyük olmalıdır.");
            if (dto.UnitsInStock <= 0)
                throw new BadRequestException("Kaydedilecek Ürün adedi 0'dan büyük olmalıdır.");
            //validasyonlar....
            var product = _mapper.Map<Product>(dto);
            await _repo.UpdateAsync(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }
    }
}
