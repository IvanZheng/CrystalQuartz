using Newtonsoft.Json;

namespace CrystalQuartz.WebFramework
{
    using System.Linq;
    using System.Reflection;
    using CrystalQuartz.WebFramework.Config;

    public abstract class Application : EmptyHandlerConfig
    {
        protected Application(Assembly resourcesAssembly, string defaultResourcesProfix) : base(new AppContext(new JsonSerializer(), resourcesAssembly, defaultResourcesProfix))
        {
        }

        public abstract IHandlerConfig Config { get; }

        public RunningApplication Run()
        {
            return new RunningApplication(Config.Handlers.ToArray());
        }
    }
}