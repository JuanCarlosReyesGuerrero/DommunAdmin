using DommunAdmin.ServicesLayer.Interfaces;
using DommunAdmin.ServicesLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<IServiceApi, ServiceApi>();
builder.Services.AddScoped<IAgenteService, AgenteService>();
builder.Services.AddScoped<IInmobiliariaService, InmobiliariaService>();
builder.Services.AddScoped<IAutenticarService, AutenticarService>();
builder.Services.AddScoped<ICommonServices, CommonServices>();
builder.Services.AddScoped(typeof(ICiudadService), typeof(CiudadService));
builder.Services.AddScoped(typeof(IEstadoPropiedadService), typeof(EstadoPropiedadService));
builder.Services.AddScoped(typeof(IFotografiaService), typeof(FotografiaService));
builder.Services.AddScoped(typeof(IFotografiaPropiedadService), typeof(FotografiaPropiedadService));
builder.Services.AddScoped(typeof(IPropiedadService), typeof(PropiedadService));
builder.Services.AddScoped(typeof(ITipoPropiedadService), typeof(TipoPropiedadService));
builder.Services.AddScoped(typeof(ITipoOfertaService), typeof(TipoOfertaService));




//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
