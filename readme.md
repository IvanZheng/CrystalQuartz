![](http://guryanovev.github.io/CrystalQuartz/demo_v42.png)

Crystal Quartz Panel is a lightweight, completely pluggable module for displaying Quartz.NET scheduler jobs information.

[![Build Status](https://travis-ci.org/guryanovev/CrystalQuartz.svg?branch=master)](https://travis-ci.org/guryanovev/CrystalQuartz)
[![Join the chat at https://gitter.im/guryanovev/CrystalQuartz](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/guryanovev/CrystalQuartz?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# Features #
  * This fork supports NetCoreApp!
  * simple and lightweight, could be embedded into existing application:
    * supports NetCoreApp web or standalone applications;
  * displays basic scheduler information:
    * scheduler state and properties;
    * triggers by jobs and groups;
    * job properties (`JobDataMap`);
  * ability to perform basic scheduler actions:
    * pause/resume triggers jobs and groups;
    * start/shutdown a scheduler;
    * delete (unschedule) job;
    * execute a job on demand ("Trigger Now").
  * easy integration with a *remote scheduler* (see [examples](https://github.com/guryanovev/CrystalQuartz/tree/master/examples));

# Getting started #

CrystalQuartzPanel is implemented as a module that can be embedded into an existing application. Getting started strategy depends on a kind of environment you use.

## Option : NetCoreApp ##


**Examples**
- [aspnetcore Simple site](https://github.com/IvanZheng/CrystalQuartz/tree/aspnetcore/src/CrystalQuartz.Web.DemoCore)
                                         
  ```cs
   public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              IApplicationLifetime applicationLifetime)
   {
      .......
      app.UseCrystalQuartz(new SchedulerProvider());
      .......
   }
  
   Use http://localhost:5000/quartz  to browse the quartz dashboard.
**Option 2.2: If Quartz Scheduler works in a separate application (remote scheduler):**
**Currently Quartz 3.0.4 for DotNetCore doesn't support RemotingSchedulerExporter !!!**
  1. Install [CrystalQuartz.Remote](http://nuget.org/List/Packages/CrystalQuartz.Remote) NuGet package.
  
  ```Install-Package CrystalQuartz.Remote```
 
  2. Customize url of the remote scheduler in web config file:
 
  ```XML
  <crystalQuartz>
      <provider>
          <add property="Type" 
               value="CrystalQuartz.Core.SchedulerProviders.RemoteSchedulerProvider, CrystalQuartz.Core" />
          <add property="SchedulerHost" 
               value="tcp://localhost:555/QuartzScheduler" /> <!-- Customize URL here -->
      </provider>
  </crystalQuartz>
  ```
  3. Run you application and go to `YOUR_APP_URL/CrystalQuartzPanel.axd`

**Examples**
- [Simple Scheduler Example](https://github.com/guryanovev/CrystalQuartz/tree/owin/examples/04_SystemWeb_Simple)
- [Remote Scheduler Example](https://github.com/guryanovev/CrystalQuartz/tree/owin/examples/05_SystemWeb_Remote)

# Custom styles #

It is possible to apply some custom css to CrystalQuartz UI. To do so you need:

1. create a css file somewhere in your web application;
2. add a reference to this css file in CrystalQuartz config:
 
  ```xml
  <sectionGroup name="crystalQuartz" type="CrystalQuartz.Web.Configuration.CrystalQuartzConfigurationGroup">
    <section 
        name="provider" 
        type="CrystalQuartz.Web.Configuration.ProviderSectionHandler" 
        requirePermission="false" 
        allowDefinition="Everywhere" />
    <!-- options section is required -->
    <section 
        name="options" 
        type="CrystalQuartz.Web.Configuration.CrystalQuartzOptionsSection" 
        requirePermission="false" 
        allowDefinition="Everywhere" />
  </sectionGroup>

  <!-- ... -->
  <crystalQuartz>
    <!-- ... -->
    <options
        customCssUrl="CUSTOM_CSS_URL">
    </options>
  </crystalQuartz>
  ```

See [custom styles example](//github.com/guryanovev/CrystalQuartz/tree/master/examples/06_CustomStyles) for details.

# Building from source #

Please use `Build.bat` script to build the project locally. **Rebuilding directly from Visual Studio would not work correctly** because some client-side assets should be regenerated. `Build.bat` is a bootstrapper for [Rosalia build tool](https://github.com/rosaliafx/Rosalia). Prerquirements:

* Typescript should be installed on your machine and `tsc` command should be globally available 

Once the build completes successfully, you can Run the VS project as usually.

# Collaboration #

Please use [gitter](https://gitter.im/guryanovev/CrystalQuartz?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) to ask questions. Fill free to report issues and open pull requests.

# Changelog #

**Latest update:**

Added an ability to add triggers for existing Jobs

<small>Add Trigger option in Job dropdown:</small>

<img src="http://guryanovev.github.io/CrystalQuartz/add_trigger_1.png" title="Add trigger option">

<small>Add Trigger form:</small>

<img src="http://guryanovev.github.io/CrystalQuartz/add_trigger_2.png" title="Add trigger option">

[See full changelog](//github.com/guryanovev/CrystalQuartz/wiki/Changelog)
