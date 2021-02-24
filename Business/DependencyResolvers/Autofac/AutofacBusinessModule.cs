using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.Features.AttributeFilters;
using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.RestSharp;
using Core.Utilities.RestsharpClient.ApiClient;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();



            //builder.RegisterType<ApiService>().As<IApiService>()
            //    .WithParameter("baseUrl", "https://localhost:44334/api/")
            //    .Named<IApiService>("WebApi")
            //    //.AsImplementedInterfaces()
            //    .WithAttributeFiltering();

            //builder.RegisterType<ApiService>().As<IApiService>()
            //    .WithParameter("baseUrl", "https://api.genelpara.com/embed/")
            //    .Named<IApiService>("GenelParaWebApi")
            //    //.AsImplementedInterfaces()
            //    .WithAttributeFiltering();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}