using CommonTypesLayer.Model;
using System.ComponentModel.DataAnnotations;

namespace Ah.Model.Entities
{
    // new Product().ProductName.(StingMetodlar)
    // new Product().Category.CategoryName
    public class Product : IEntity
    {
        //Veri Tabanındaki Tablonun Satırlarını burda modelliyorum. Tablo ismi aynı olmalı. eğer tablo ismini farklı yapacaksak bazı işlemler yapmamız gerekir. Tabloda bulunann Kolon isimleri de aynı olmalı. Eğer onlarıda farklı kullanacaksak bazı işlemler yapmalıyız...
        //Veri Tabanındaki tablo kolonlarının hepsini almak zorunda değiliz. İşimize yarayanları alsak yeter. Dikkat etmemiz gereken bir diğer COLON ise Tablolar arası ilişki kurulan Kolonları da mutlaka almalıyız...
        // Dikkat etmemiz gereken bir diğer konu ise kolonun NOT NULL durumudur. eğer biz burada kolonu NOT NULL olarak işaretlersek ve arayüzden buraya null ifadesi gelirse hata alırız...
        //Bu tablo Category Tablosu ile ilişkili yani her bir product'ın bir tane cateory'si var ve bunu burada anlatmam lazım...
        public int ProductID { get; set; }
        //validasyonları burda yapabiliriz..
        [Required(ErrorMessage = "Ürün Adı Alanı gereklidir.")]
        [MaxLength(10)]
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        //[Range(0, 999)]
        public short? UnitsInStock { get; set; }
        public int? CategoryID { get; set; }
        //Navigation Property
        public Category? Category { get; set; }
    }
}
