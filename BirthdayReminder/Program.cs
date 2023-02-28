using BirthdayReminder.RepositoryLayer;
using BirthdayReminder.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
IServiceCollection serviceCollection = builder.Services.AddScoped<IFriendSL, FriendSL>();
IServiceCollection serviceCollection1 = builder.Services.AddScoped<IFriendRL, FriendRL>();
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

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
