using System.Threading.Tasks;
using CrystalQuartz.Application;
using CrystalQuartz.Core;
using CrystalQuartz.Core.SchedulerProviders;
using CrystalQuartz.WebFramework;
using CrystalQuartz.WebFramework.AspNetCore;
using CrystalQuartz.WebFramework.HttpAbstractions;
using Microsoft.AspNetCore.Http;

namespace CrystalQuartz.Owin
{
    public class CrystalQuartzPanelMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RunningApplication _runningApplication;

        public CrystalQuartzPanelMiddleware(RequestDelegate next,
                                            ISchedulerProvider schedulerProvider,
                                            CrystalQuartzOptions options)
        {
            WebFramework.Application application = new CrystalQuartzPanelApplication(
                                                                                     schedulerProvider,
                                                                                     new DefaultSchedulerDataProvider(schedulerProvider),
                                                                                     options);

            _runningApplication = application.Run();
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            IFormCollection formCollection = null;
            if (context.Request.HasFormContentType)
            {
                formCollection = await context.Request.ReadFormAsync();
            }
            IRequest owinRequest = new QuartzRequest(context.Request.Query, formCollection);
            IResponseRenderer responseRenderer = new QuartzResponseRenderer(context);
            _runningApplication.Handle(owinRequest, responseRenderer);
            //if (!handleResult.IsHandled)
            //{
            //    await _next.Invoke(context);
            //}
        }
    }
}