using CameraServicesPlatform.BackEnd.Application.IService;
using CameraServicesPlatform.BackEnd.Common.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CameraServicesPlatform.BackEnd.Application.Service
{
    public class SmsService : GenericBackendService, ISmsService
    {
        public SmsService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<AppActionResult> SendMessage(string message, string phoneNumber)
        {
            AppActionResult result = new AppActionResult();
            try
            {
                var accountSid = "AC11ff9b879ce539dd481f4e5830f6e54a";
                var authToken = "GO5791d795d03e488f808efa6006cf3e03";
                TwilioClient.Init(accountSid, authToken);

                var apiResponsse = MessageResource.Create(
                   body: $"Your code login: {message}",
                   from: new Twilio.Types.PhoneNumber("+1 209 780 7203"),
                   to: new Twilio.Types.PhoneNumber($"+84{phoneNumber}")
               );

                result.Result = apiResponsse.Status;
            }
            catch (Exception e)
            {
                result = BuildAppActionResultError(result, e.Message);
            }

            return result;
        }
    }
}
