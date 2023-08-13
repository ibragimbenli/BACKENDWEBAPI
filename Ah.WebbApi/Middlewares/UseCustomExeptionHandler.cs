using Ah.Business.CustomExceptions;
using Ah.Model.Entities;
using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Ah.WebbApi.Middlewares
{
    public static class UseCustomExeptionHandler
    {
        public static void UseCustomExeption(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                  {
                      context.Response.ContentType = "application/json";

                      var exeptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                      var statusCode = StatusCodes.Status500InternalServerError;
                      //if (statusCode == StatusCodes.Status400BadRequest)
                      //{

                      //}
                      switch (exeptionFeature.Error)
                      {
                          case BadRequestException:
                              statusCode = StatusCodes.Status400BadRequest;
                              break;
                          case NoContentException:
                              statusCode = StatusCodes.Status204NoContent;
                              break;
                          case NotFoundException:
                              statusCode = StatusCodes.Status404NotFound;
                              break;
                      }
                      context.Response.StatusCode = statusCode;
                      var response = ApiResponse<Product>.Fail(statusCode, exeptionFeature.Error.Message);
                      await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                  });
            });
        }
    }
}


