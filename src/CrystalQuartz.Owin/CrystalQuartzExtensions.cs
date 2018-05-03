using System;
using CrystalQuartz.Application;
using CrystalQuartz.Core.SchedulerProviders;
using CrystalQuartz.Owin;
using Microsoft.AspNetCore.Builder;
using Quartz;

namespace CrystalQuartz.AspNetCore
{
    public static class CrystalQuartzExtensions
    {
        public static IApplicationBuilder UseCrystalQuartz(
            this IApplicationBuilder app,
            IScheduler scheduler)
        {
            UseCrystalQuartz(app, scheduler, null);
            return app;
        }

        public static IApplicationBuilder UseCrystalQuartz(
            this IApplicationBuilder app,
            IScheduler scheduler,
            CrystalQuartzOptions options)
        {
            app.UseCrystalQuartz(() => scheduler, options);
            return app;
        }

        public static IApplicationBuilder UseCrystalQuartz(
            this IApplicationBuilder app,
            Func<IScheduler> schedulerProvider)
        {
            UseCrystalQuartz(app, schedulerProvider, null);
            return app;
        }

        public static IApplicationBuilder UseCrystalQuartz(
            this IApplicationBuilder app,
            Func<IScheduler> schedulerProvider,
            CrystalQuartzOptions options)
        {
            app.UseCrystalQuartz(new FuncSchedulerProvider(schedulerProvider), options);
            return app;
        }

        public static IApplicationBuilder UseCrystalQuartz(
            this IApplicationBuilder app,
            ISchedulerProvider scheduleProvider)
        {
            UseCrystalQuartz(app, scheduleProvider, null);
            return app;
        }

        public static IApplicationBuilder UseCrystalQuartz(
            this IApplicationBuilder app,
            ISchedulerProvider scheduleProvider,
            CrystalQuartzOptions options)
        {
            var actualOptions = options ?? new CrystalQuartzOptions();
            var url = actualOptions.Path ?? "/quartz";

            app.Map(url, privateApp => { privateApp.UseMiddleware(typeof(CrystalQuartzPanelMiddleware), scheduleProvider, actualOptions); });
            return app;
        }
    }
}