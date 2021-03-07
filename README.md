

# 🏴 ReCapProject - Araç Kiralama Sistemi

![sekil](https://user-images.githubusercontent.com/59607113/110251712-d9be1d00-7f92-11eb-9955-dacc119eb128.png)
<This repository includes **Yazılım Geliştirici Yetiştirme Kampı** works. Here is the **Car Rental Project**!

![01_entitiesLayer](https://user-images.githubusercontent.com/59607113/110251950-235b3780-7f94-11eb-88c6-30b63e175692.png)
![03_businessLayer](https://user-images.githubusercontent.com/59607113/110252273-9e711d80-7f95-11eb-92bf-0b0d146ec96c.png)
![02_dataAccessLayer](https://user-images.githubusercontent.com/59607113/110252274-9fa24a80-7f95-11eb-8d2c-3badda0a2197.png)
![04_reqirement](https://user-images.githubusercontent.com/59607113/110252275-9fa24a80-7f95-11eb-9c04-ed30075124c4.png)
![05_database](https://user-images.githubusercontent.com/59607113/110252286-b779ce80-7f95-11eb-9c0a-8ce6fe7a178c.png)
![01_core_desc](https://user-images.githubusercontent.com/59607113/110252887-a41c3280-7f98-11eb-9384-84830062abe7.png)
![02_database_desc](https://user-images.githubusercontent.com/59607113/110252890-a4b4c900-7f98-11eb-9f72-b4f090201b97.png)
![03_business_desc](https://user-images.githubusercontent.com/59607113/110252891-a4b4c900-7f98-11eb-8acd-e54b5b5aeaa9.png)
![04_entities_desc](https://user-images.githubusercontent.com/59607113/110252892-a54d5f80-7f98-11eb-863b-0cc4e01ee3a4.png)
![05_dal_desc](https://user-images.githubusercontent.com/59607113/110252893-a54d5f80-7f98-11eb-87df-ef2d2ae4f684.png)


├─ Business
│  ├─ Abstract
│  │  ├─ IAuthService.cs
│  │  ├─ IBrandService.cs
│  │  ├─ ICarImageService.cs
│  │  ├─ ICarService.cs
│  │  ├─ IColorService.cs
│  │  ├─ ICustomerService.cs
│  │  ├─ IRentalService.cs
│  │  └─ IUserService.cs
│  ├─ BusinessAspects
│  │  └─ Autofac
│  │     └─ SecuredOperation.cs
│  ├─ Concrete
│  │  ├─ AuthManager.cs
│  │  ├─ BrandManager.cs
│  │  ├─ CarImageManager.cs
│  │  ├─ CarManager.cs
│  │  ├─ ColorManager.cs
│  │  ├─ CustomerManager.cs
│  │  ├─ RentalManager.cs
│  │  └─ UserManager.cs
│  ├─ Constants
│  │  ├─ Consts.cs
│  │  └─ Messages.cs
│  ├─ DependencyResolvers
│  │  └─ Autofac
│  │     └─ AutofacBusinessModule.cs
│  ├─ ValidationTools
│  │  └─ FluentValidation
│  │     ├─ AddCarImagesDtoValidator.cs
│  │     └─ CarValidator.cs
│  └─ Business.csproj
├─ ConsoleUI
│  ├─ ConsoleManager.cs
│  ├─ ConsoleUI.csproj
│  ├─ IConsoleService.cs
│  └─ Program.cs
├─ Core
│  ├─ Aspects
│  │  └─ Autofac
│  │     ├─ Caching
│  │     │  ├─ CacheAspect.cs
│  │     │  └─ CacheRemoveAspect.cs
│  │     ├─ CancellationTokenAspect
│  │     │  └─ CancellationTokenAspect.cs
│  │     ├─ Performance
│  │     │  └─ PerformanceAspect.cs
│  │     ├─ Transaction
│  │     │  └─ TransactionScopeAspect.cs
│  │     └─ Validation
│  │        └─ ValidationAspect.cs
│  ├─ CrossCuttingConcerns
│  │  ├─ Attributes
│  │  │  └─ SwaggerIgnoreAttribute.cs
│  │  ├─ Caching
│  │  │  ├─ Microsoft
│  │  │  │  └─ MemoryCacheManager.cs
│  │  │  └─ ICacheManager.cs
│  │  └─ Validation
│  │     └─ ValidationTool.cs
│  ├─ DataAccess
│  │  ├─ EntityFramework
│  │  │  └─ EfEntityRepositoryBase.cs
│  │  └─ IEntityRepository.cs
│  ├─ Entities
│  │  ├─ Concrete
│  │  │  ├─ OperationClaim.cs
│  │  │  ├─ User.cs
│  │  │  └─ UserOperationClaim.cs
│  │  ├─ IDto.cs
│  │  ├─ IEntity.cs
│  │  └─ IKurumEntity.cs
│  ├─ Extensions
│  │  ├─ ClaimExtensions.cs
│  │  ├─ ClaimsPrincipalExtensions.cs
│  │  ├─ IQueryable.cs
│  │  └─ ServiceCollectionExtensions.cs
│  ├─ Utilities
│  │  ├─ Business
│  │  │  └─ BusinessRules.cs
│  │  ├─ FileHelper
│  │  │  ├─ FileHelper.cs
│  │  │  └─ IFileHelper.cs
│  │  ├─ Interceptors
│  │  │  ├─ AspectInterceptorSelector.cs
│  │  │  ├─ MethodInterception.cs
│  │  │  └─ MethodInterceptionBaseAttribute.cs
│  │  ├─ IoC
│  │  │  ├─ ICoreModule.cs
│  │  │  └─ ServiceTool.cs
│  │  ├─ Messages
│  │  │  └─ ValidationAspectMessages.cs
│  │  ├─ RestSharp
│  │  │  ├─ ApiService.cs
│  │  │  └─ IApiService.cs
│  │  ├─ Results
│  │  │  ├─ DataResult.cs
│  │  │  ├─ ErrorDataResult.cs
│  │  │  ├─ ErrorResult.cs
│  │  │  ├─ IDataResult.cs
│  │  │  ├─ IResult.cs
│  │  │  ├─ Result.cs
│  │  │  ├─ SuccessDataResult.cs
│  │  │  └─ SuccessResult.cs
│  │  └─ Security
│  │     ├─ Encryption
│  │     │  ├─ SecurityKeyHelper.cs
│  │     │  └─ SigningCredentialsHelper.cs
│  │     ├─ Hashing
│  │     │  └─ HashingHelper.cs
│  │     └─ Jwt
│  │        ├─ AccessToken.cs
│  │        ├─ ITokenHelper.cs
│  │        ├─ JwtHelper.cs
│  │        └─ TokenOptions.cs
│  └─ Core.csproj
├─ DataAccess
│  ├─ Abstract
│  │  ├─ IBrandDal.cs
│  │  ├─ ICarDal.cs
│  │  ├─ ICarImagesDal.cs
│  │  ├─ IColorDal.cs
│  │  ├─ ICustomerDal.cs
│  │  ├─ IRentalDal.cs
│  │  └─ IUserDal.cs
│  ├─ Concrete
│  │  ├─ EntityFramework
│  │  │  ├─ EfBrandDal.cs
│  │  │  ├─ EfCarDal.cs
│  │  │  ├─ EfCarImagesDal.cs
│  │  │  ├─ EfColorDal.cs
│  │  │  ├─ EfCustomerDal.cs
│  │  │  ├─ EfRentalDal.cs
│  │  │  ├─ EfUserDal.cs
│  │  │  └─ ReCapContext.cs
│  │  └─ InMemory
│  │     └─ InMemoryCarDal.cs
│  └─ DataAccess.csproj
├─ Entities
│  ├─ Concrete
│  │  ├─ Brand.cs
│  │  ├─ Car.cs
│  │  ├─ CarImage.cs
│  │  ├─ Color.cs
│  │  ├─ Customer.cs
│  │  └─ Rental.cs
│  ├─ DTOs
│  │  ├─ AddCarImagesDto.cs
│  │  ├─ BrandGetListWithCarsDto.cs
│  │  ├─ CarDetailsDto.cs
│  │  ├─ UpdateCarImageDto.cs
│  │  ├─ UserForLoginDto.cs
│  │  └─ UserForRegisterDto.cs
│  └─ Entities.csproj
├─ WebAPI
│  ├─ .config
│  │  └─ dotnet-tools.json
│  ├─ Controllers
│  │  ├─ AuthController.cs
│  │  ├─ BrandsController.cs
│  │  ├─ CarImagesController.cs
│  │  ├─ CarsController.cs
│  │  ├─ ColorsController.cs
│  │  ├─ CustomerController.cs
│  │  ├─ DenemeController.cs
│  │  ├─ RentalsController.cs
│  │  └─ UsersController.cs
│  ├─ Filters
│  │  └─ SwaggerSkipPropertyFilter.cs
│  ├─ Properties
│  │  └─ launchSettings.json
│  ├─ wwwroot
│  │  └─ upload
│  │     └─ images
│  │        ├─ 46af6097-c7c6-4eb3-9338-0aafff1e8351.jpg
│  │        ├─ 52fe94ad-fd6c-4453-b89e-9fe20f728328.jpg
│  │        ├─ 65392454-d199-40f9-973e-752f33430169.jpg
│  │        ├─ 6bff163d-dd68-4006-9f85-3d3955a0d37b.png
│  │        ├─ 8d7ee3a0-ddf2-4750-a9d7-628e18451361.jpg
│  │        ├─ b0165daf-51aa-47eb-b6a4-e3f55007ebdc.png
│  │        ├─ cb73070e-97eb-4dc7-a448-382ea0c9f9ea.jpg
│  │        └─ f9925634-b821-4cff-88b6-4543ba71bd65_3_3_2021.png
│  ├─ Program.cs
│  ├─ Startup.cs
│  ├─ WebAPI.csproj
│  ├─ appsettings.Development.json
│  ├─ appsettings.json
│  └─ hck.cd
├─ WebApplication1
│  ├─ Controllers
│  │  └─ HomeController.cs
│  ├─ Helpers
│  │  ├─ HttpRequestHelper.cs
│  │  └─ IHttpRequestHelper.cs
│  ├─ Models
│  │  └─ ViewDataResult.cs
│  ├─ Properties
│  │  └─ launchSettings.json
│  ├─ Views
│  │  ├─ Home
│  │  │  ├─ Index.cshtml
│  │  │  └─ Privacy.cshtml
│  │  ├─ Shared
│  │  │  ├─ _Layout.cshtml
│  │  │  └─ _ValidationScriptsPartial.cshtml
│  │  ├─ _ViewImports.cshtml
│  │  └─ _ViewStart.cshtml
│  ├─ wwwroot
│  │  ├─ css
│  │  │  └─ site.css
│  │  ├─ js
│  │  │  └─ site.js
│  │  ├─ lib
│  │  │  ├─ bootstrap
│  │  │  │  ├─ dist
│  │  │  │  │  ├─ css
│  │  │  │  │  │  ├─ bootstrap-grid.css
│  │  │  │  │  │  ├─ bootstrap-grid.css.map
│  │  │  │  │  │  ├─ bootstrap-grid.min.css
│  │  │  │  │  │  ├─ bootstrap-grid.min.css.map
│  │  │  │  │  │  ├─ bootstrap-reboot.css
│  │  │  │  │  │  ├─ bootstrap-reboot.css.map
│  │  │  │  │  │  ├─ bootstrap-reboot.min.css
│  │  │  │  │  │  ├─ bootstrap-reboot.min.css.map
│  │  │  │  │  │  ├─ bootstrap.css
│  │  │  │  │  │  ├─ bootstrap.css.map
│  │  │  │  │  │  ├─ bootstrap.min.css
│  │  │  │  │  │  └─ bootstrap.min.css.map
│  │  │  │  │  └─ js
│  │  │  │  │     ├─ bootstrap.bundle.js
│  │  │  │  │     ├─ bootstrap.bundle.js.map
│  │  │  │  │     ├─ bootstrap.bundle.min.js
│  │  │  │  │     ├─ bootstrap.bundle.min.js.map
│  │  │  │  │     ├─ bootstrap.js
│  │  │  │  │     ├─ bootstrap.js.map
│  │  │  │  │     ├─ bootstrap.min.js
│  │  │  │  │     └─ bootstrap.min.js.map
│  │  │  │  └─ LICENSE
│  │  │  ├─ jquery-validation-unobtrusive
│  │  │  │  ├─ LICENSE.txt
│  │  │  │  ├─ jquery.validate.unobtrusive.js
│  │  │  │  └─ jquery.validate.unobtrusive.min.js
│  │  │  ├─ jquery-validation
│  │  │  │  ├─ dist
│  │  │  │  │  ├─ additional-methods.js
│  │  │  │  │  ├─ additional-methods.min.js
│  │  │  │  │  ├─ jquery.validate.js
│  │  │  │  │  └─ jquery.validate.min.js
│  │  │  │  └─ LICENSE.md
│  │  │  └─ jquery
│  │  │     ├─ dist
│  │  │     │  ├─ jquery.js
│  │  │     │  ├─ jquery.min.js
│  │  │     │  └─ jquery.min.map
│  │  │     └─ LICENSE.txt
│  │  └─ favicon.ico
│  ├─ Program.cs
│  ├─ Startup.cs
│  ├─ appsettings.Development.json
│  └─ appsettings.json
├─ .gitattributes
├─ .gitignore
├─ README.md
├─ ReCapProject.sln
└─ hack.cd
