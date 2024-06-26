using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.BusinessLayer.Concrete;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.DataAccessLayer.EntityFramework;
using MilkyProject.EntityLayer.Concrete;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IAboutService, AboutMenager>();
builder.Services.AddScoped<IAboutDal,EfAboutDal>();

builder.Services.AddScoped<IAddressService, AddressMenager>();
builder.Services.AddScoped<IAddressDal, EfAddressDal>();

builder.Services.AddScoped<IAdminService,AdminMenager>();
builder.Services.AddScoped<IAdminDal,EfAdminDal>();

builder.Services.AddScoped<ICategoryService,CategoryMenager>();
builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();

builder.Services.AddScoped<IContactService, ContactMenager>();
builder.Services.AddScoped<IContactDal,EfContactDal>();

builder.Services.AddScoped<ISliderService,SliderMenager>();
builder.Services.AddScoped<ISliderDal,EfSliderDal>();

builder.Services.AddScoped<IProductService,ProductMenager>();
builder.Services.AddScoped<IProductDal,EfProductDal>();

builder.Services.AddScoped<IGalleryService,GalleryMenager>();
builder.Services.AddScoped<IGalleryDal,EfGalleryDal>();

builder.Services.AddScoped<ICarouselService, CarouselMenager>();
builder.Services.AddScoped<ICarouselDal,EfCarouselDal>();

builder.Services.AddScoped<ILetterService,LetterMenager>();
builder.Services.AddScoped<ILetterDal,EfLetterDal>();

builder.Services.AddScoped<ITestimonialDal,EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialMenager>();

builder.Services.AddScoped<IFeatureDal,EfFeatureDal>();
builder.Services.AddScoped<IFeatureService,FeatureMenager>();

builder.Services.AddScoped<ITeamService,TeamMenager>();
builder.Services.AddScoped<ITeamDal,EfTeamDal>();

builder.Services.AddScoped<IServiceService,ServiceMenager>();
builder.Services.AddScoped<IServiceDal,EfServiceDal>();

builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<MilkyContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
