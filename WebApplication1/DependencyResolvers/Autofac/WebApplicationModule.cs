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
            builder.RegisterType<ApiService>()
                .Keyed<IApiService>("WebApi")
                .AsImplementedInterfaces()
                .WithParameter("baseUrl", "https://localhost:44334/api/");

            builder.RegisterType<ApiService>()
                .Keyed<IApiService>("GenelParaWebApi")
                .AsImplementedInterfaces()
                .WithParameter("baseUrl", "https://api.genelpara.com/embed/");

            builder.RegisterType<HttpRequestHelper>().As<IHttpRequestHelper>().SingleInstance(); 

            //builder.RegisterAssemblyTypes(typeof(ApiService).Assembly, typeof(Startup).Assembly)
            //    .InstancePerDependency()
            //    .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(typeof(IApiService).Assembly)
            //    .AsImplementedInterfaces();

            ////foreach (Type tp in AppDomain.CurrentDomain.GetAssemblies().Where(t => t.IsSubclassOf(typeof(Module))))

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
