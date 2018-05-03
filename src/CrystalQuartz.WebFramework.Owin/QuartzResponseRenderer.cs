using CrystalQuartz.WebFramework.HttpAbstractions;
using Microsoft.AspNetCore.Http;

namespace CrystalQuartz.WebFramework.AspNetCore
{
    public class QuartzResponseRenderer : IResponseRenderer
    {
        private readonly HttpContext _context;

        public QuartzResponseRenderer(HttpContext context)
        {
            _context = context;
        }

        public void Render(HttpAbstractions.Response response)
        {
            _context.Response.StatusCode = response.StatusCode;
            _context.Response.ContentType = response.ContentType;
            response.ContentFiller?.Invoke(_context.Response.Body);
        }
    }
}