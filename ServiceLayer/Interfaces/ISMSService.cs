﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace ServiceLayer.Interfaces
{
    public interface ISMSService
    {
        Task<MessageResource> SendAsync(string message, string to);
    }
}
