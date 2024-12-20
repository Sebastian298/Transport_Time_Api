using Transport_Time.Data;
using Transport_Time.Repositories;
using Transport_Time.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddSingleton(provider => new DapperContext(connectionString!));
builder.Services.AddHttpClient<HttpService>();
builder.Services.AddScoped<IDapperService,DapperService>();
builder.Services.AddScoped<RoutingService>();
builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "WebSitesPolicy", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("WebSitesPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
