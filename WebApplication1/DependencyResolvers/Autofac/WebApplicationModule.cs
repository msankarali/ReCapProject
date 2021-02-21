using Autofac;
using Autofac.Features.AttributeFilters;
using Core.Utilities.RestSharp;
using Core.Utilities.RestsharpClient.ApiClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Helpers;

namespace WebApplication1.DependencyResolvers.Autofac
{
    public class WebApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            //var moduleType = typeof(BaseModule);
            //foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic))
            //    foreach (var type in assembly.GetTypes().Where(moduleType.IsAssignableFrom))
            //        if (!type.IsAbstract)
            //        {
            //            var module = (BaseModule)Activator.CreateInstance(type);
            //            builder.RegisterModule(module);
            //        }
        }
    }
}
