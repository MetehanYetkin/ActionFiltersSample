using ActionFiltersSample.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFiltersSample.ActionFilters
{
    public class CodeActionFilters : IAsyncActionFilter  //.net içersinden gelen bir Interface
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) // implement interface 
        {
            string code = "merchantCore"; // Büyük harf ile yazmamamız gerkiyor . 

            //Get Data
           var merchantCode  =  context.RouteData.Values[code];

            //Set Data 
            var baseRequest = context.ActionArguments // ActionArguments içerisinde BaseRequest olan ilk değeri getir . 
                .FirstOrDefault(x=>x.Value != null && typeof(MerchantBaseRequest)
                .IsAssignableFrom(x.Value.GetType()));

            if (baseRequest.Value is not null ) // eğer değer var ise 
            {
                var request = (MerchantBaseRequest)baseRequest.Value; // artık gönderilen değeri MerchantBaseRequest olarak cast ettik . 
                request.MerchantCode = merchantCode.ToString();

            }
            else
            {
                context.ActionArguments.Add(code, merchantCode);


            }


            await next();
        
        }
    }
}
