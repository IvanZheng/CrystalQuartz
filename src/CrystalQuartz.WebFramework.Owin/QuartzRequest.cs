using CrystalQuartz.WebFramework.HttpAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace CrystalQuartz.WebFramework.AspNetCore
{
    public class QuartzRequest : IRequest
    {
        private readonly IQueryCollection _query;
        private readonly IFormCollection _body;

        public QuartzRequest(IQueryCollection query, IFormCollection body)
        {
            _query = query;
            _body = body;
        }

        public string this[string key]
        {
            get
            {
                _query.TryGetValue(key, out var values);
                if (values.Count == 0)
                {
                    _body?.TryGetValue(key, out values);
                }
                return values.ToString();
            }
        }
    }
}