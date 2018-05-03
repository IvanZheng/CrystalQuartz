using Newtonsoft.Json;

namespace CrystalQuartz.WebFramework.Response
{
    using System.IO;
    using CrystalQuartz.WebFramework.HttpAbstractions;
    using CrystalQuartz.WebFramework.Utils;

    public class JsonResponseFiller : DefaultResponseFiller
    {
        private readonly object _model;
        private readonly JsonSerializer _serializer;

        public JsonResponseFiller(object model, JsonSerializer serializer)
        {
            _model = model;
            _serializer = serializer;
        }

        public override string ContentType => "application/json";

        protected override void InternalFillResponse(Stream outputStream, IRequest request)
        {
            var serialized = _serializer.Serialize(_model);
            using (var writer = new StreamWriter(outputStream))
            {
                writer.WriteLine(serialized);
            }
        }
    }
}