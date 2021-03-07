
# 🏴 ReCapProject - Araç Kiralama Sistemi

![sekil](https://user-images.githubusercontent.com/59607113/110251712-d9be1d00-7f92-11eb-9955-dacc119eb128.png)
This repository is all about **Yazılım Geliştirici Yetiştirme Kampı** works. Here is the **Car Rental Project**!

![06_core](https://user-images.githubusercontent.com/59607113/110253482-a2a03980-7f9b-11eb-8d9c-09b626349499.png)

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
        
![01_entitiesLayer](https://user-images.githubusercontent.com/59607113/110251950-235b3780-7f94-11eb-88c6-30b63e175692.png)

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

![02_dataAccessLayer](https://user-images.githubusercontent.com/59607113/110252274-9fa24a80-7f95-11eb-8d2c-3badda0a2197.png)

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

![03_businessLayer](https://user-images.githubusercontent.com/59607113/110252273-9e711d80-7f95-11eb-92bf-0b0d146ec96c.png)

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

![01_core_desc](https://user-images.githubusercontent.com/59607113/110252887-a41c3280-7f98-11eb-9384-84830062abe7.png)
![02_database_desc](https://user-images.githubusercontent.com/59607113/110252890-a4b4c900-7f98-11eb-9f72-b4f090201b97.png)
![03_business_desc](https://user-images.githubusercontent.com/59607113/110252891-a4b4c900-7f98-11eb-8acd-e54b5b5aeaa9.png)
![04_entities_desc](https://user-images.githubusercontent.com/59607113/110252892-a54d5f80-7f98-11eb-863b-0cc4e01ee3a4.png)
![05_dal_desc](https://user-images.githubusercontent.com/59607113/110252893-a54d5f80-7f98-11eb-87df-ef2d2ae4f684.png)
