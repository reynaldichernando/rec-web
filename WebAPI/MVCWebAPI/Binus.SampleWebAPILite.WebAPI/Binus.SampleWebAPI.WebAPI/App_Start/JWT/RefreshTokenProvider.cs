using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Binus.SampleWebAPI.WebAPI.App_Start.JWT
{
    public class RefreshTokenProvider: AuthenticationTokenProvider
    {
        public override void Create(AuthenticationTokenCreateContext context)
        {
            int expire = Convert.ToInt16(ConfigurationManager.AppSettings["TokenRefreshTime"]);
            context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddMinutes(expire));
            context.SetToken(context.SerializeTicket());
        }

        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }
}