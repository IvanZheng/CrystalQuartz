using Newtonsoft.Json;

namespace CrystalQuartz.WebFramework.Config
{
    using System.Reflection;

    public class AppContext
    {
        private readonly JsonSerializer _javaScriptSerializer;
        private readonly Assembly _resourcesAssembly;
        private readonly string _defautResourcePrefix;

        public AppContext(JsonSerializer javaScriptSerializer, Assembly resourcesAssembly, string defautResourcePrefix)
        {
            _javaScriptSerializer = javaScriptSerializer;
            _resourcesAssembly = resourcesAssembly;
            _defautResourcePrefix = defautResourcePrefix;
        }

        public JsonSerializer JavaScriptSerializer
        {
            get { return _javaScriptSerializer; }
        }

        public Assembly ResourcesAssembly
        {
            get { return _resourcesAssembly; }
        }

        public string DefautResourcePrefix
        {
            get { return _defautResourcePrefix; }
        }
    }
}