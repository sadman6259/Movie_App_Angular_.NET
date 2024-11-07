using Microsoft.EntityFrameworkCore;
using Movie_API.Services;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Movie_API.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyName = "apikey";
        private IConfiguration configuration { get; }

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            this.configuration = configuration;
        }

       

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Query[ApiKeyName].Equals(Microsoft.Extensions.Primitives.StringValues.Empty))
            {
                string decryptedStr =
                EncriptionHelper.DecryptAes(context.Request.Query[ApiKeyName], "SecretKeyForEncryption&Descryption");
                var expectedApikey = configuration.GetValue<string>(ApiKeyName);
                if (decryptedStr != expectedApikey)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("API Key is invalid");
                    return;
                }

            }




            await _next(context);
        }
    }
}
