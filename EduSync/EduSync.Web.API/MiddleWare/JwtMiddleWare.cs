using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace EduSync.Web.API.MiddleWare
{
    public class JwtMiddleWare
    {
        private readonly RequestDelegate _next;
        public JwtMiddleWare(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/api/Login" && context.Request.Method == "Post")
            {
                await _next(context);
                return;
            }
            var authHeader = context.Request.Headers.Authorization;
            if (authHeader.Count() > 0 && authHeader.FirstOrDefault().StartsWith("Bearer"))
            {
                var token = authHeader.FirstOrDefault().Substring("Bearer".Length);
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("!@#$%^&*()!@#$%^&*()");
                try
                {
                    var claims = tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero

                    }, out var validatedToken);
                    context.User = claims;
                }
                catch
                {
                    context.Response.StatusCode = 401;
                    return;
                }
                _next(context);
            }
            _next(context);
        }
    }
        }