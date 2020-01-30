namespace Binus.SampleWebAPI.WebAPI.App_Start.JWT
{
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.DataHandler.Encoder;
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.IdentityModel.Tokens;
    using System.Text;
    using System.Threading;
    using Thinktecture.IdentityModel.Tokens;

    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private static readonly byte[] _secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

        private readonly string _issuer;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

           var signingKey = new HmacSigningCredentials(_secret);
        

            Thread.CurrentThread.CurrentCulture = new CultureInfo("id-ID");
            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
           /* var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.Default.GetBytes(ConfigurationManager.AppSettings["secret"]));
            var signingKey = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                securityKey,
                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);*/

            //new JwtSecurityTokenHandler().WriteToken()
            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(_issuer, null, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}