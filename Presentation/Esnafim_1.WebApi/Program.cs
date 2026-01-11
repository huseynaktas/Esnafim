using Esnafim_1.Application.Features.CQRS.Handlers.AboutHandlers;
using Esnafim_1.Application.Features.CQRS.Handlers.BannerHandlers;
using Esnafim_1.Application.Features.CQRS.Handlers.ContactHandlers;
using Esnafim_1.Application.Features.CQRS.Handlers.FooterAddressHandlers;
using Esnafim_1.Application.Features.CQRS.Handlers.SocialMediaHandlers;
using Esnafim_1.Application.Features.CQRS.Handlers.TestimonialHandlers;
using Esnafim_1.Application.Interfaces;
using Esnafim_1.Application.Interfaces.BusinessInterfaces;
using Esnafim_1.Application.Interfaces.BusinessOwnerInterfaces;
using Esnafim_1.Application.Interfaces.CurrentOwnerInterfaces;
using Esnafim_1.Application.Services;
using Esnafim_1.Persistence.Context;
using Esnafim_1.Persistence.Repositories;
using Esnafim_1.Persistence.Repositories.BusinessOwnerRepositories;
using Esnafim_1.Persistence.Repositories.BusinessRepositories;
using Esnafim_1.Persistence.Repositories.CurrentOwnerServiceRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<EsnafimContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBusinessRepository), typeof(BusinessRepository));
builder.Services.AddScoped(typeof(IBusinessOwnerRepository), typeof(BusinessOwnerRepository));
//builder.Services.AddScoped(typeof(ICurrentOwnerService), typeof(CurrentOwnerServiceRepository));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentOwnerService, CurrentOwnerServiceRepository>();


builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddScoped<GetFooterAddressQueryHandler>();
builder.Services.AddScoped<GetFooterAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateFooterAddressCommandHandler>();
builder.Services.AddScoped<UpdateFooterAddressCommandHandler>();
builder.Services.AddScoped<RemoveFooterAddressCommandHandler>();

builder.Services.AddScoped<GetSocialMediaQueryHandler>();
builder.Services.AddScoped<GetSocialMediaByIdQueryHandler>();
builder.Services.AddScoped<CreateSocialMediaCommandHandler>();
builder.Services.AddScoped<UpdateSocialMediaCommandHandler>();
builder.Services.AddScoped<RemoveSocialMediaCommandHandler>();

builder.Services.AddScoped<GetTestimonialQueryHandler>();
builder.Services.AddScoped<GetTestimonialByIdQueryHandler>();
builder.Services.AddScoped<CreateTestimonialCommandHandler>();
builder.Services.AddScoped<UpdateTestimonialCommandHandler>();
builder.Services.AddScoped<RemoveTestimonialCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);

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
