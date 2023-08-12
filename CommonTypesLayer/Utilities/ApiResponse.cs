using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonTypesLayer.Utilities
{
    public class ApiResponse<T>
    {//JSON formatında dışarıya açtığımız Durum sınıfını ifade ediyor.
        public T Data { get; set; }
        [JsonIgnore]//bu property sadece bizim kullanmamız için proj eiçinde kullanacağğımız bir propertydir. bu sonıf json'a dönüştürülürken bu prop dönüştürülmeyeektir.
        public int StatusCode { get; set; }
        public List<string>? ErrorMessage { get; set; }

        public static ApiResponse<T> Success(int statusCode, T data)
        {
            return new ApiResponse<T> { StatusCode = statusCode, Data = data };
        }
        public static ApiResponse<T> Success(int statusCode)
        {
            return new ApiResponse<T> { StatusCode = statusCode };
        }
        public static ApiResponse<T> Fail(int statusCode, string errorMessage)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMessage = new List<string> { errorMessage }
            };
        }
        public static ApiResponse<T> Fail(int statusCode, List<string> errorMessage)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                ErrorMessage = errorMessage
            };
        }
    }

    /*
     data:"",
    errorMessage:"hghg"
    StatusCodes
     */
}
