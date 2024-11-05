using Microsoft.Extensions.Options;
using ModelLayer.Entities;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
namespace ServiceLayer.Services
{
    public class SMSService : ISMSService
    {
        private readonly SmsMessage _smsMessage;

        public SMSService(IOptions<SmsMessage> smsMessage)
        {
            this._smsMessage = smsMessage.Value;
        }
        public async Task<MessageResource> SendAsync(string message, string to)
        {
            TwilioClient.Init(_smsMessage.AccountSID, _smsMessage.AuthToken);
            var result = await MessageResource.CreateAsync(
                body: message,
                from: new PhoneNumber(_smsMessage.PhoneNumber),
                to: new PhoneNumber(to)
            );
            return result;
        }
    }
}
