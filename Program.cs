var builder = WebApplication.CreateBuilder(args);



//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "Frontend", policyBuilder =>
//    {
//        policyBuilder.WithOrigins("http://127.0.0.1:5500");
//        policyBuilder.AllowAnyHeader();
//        policyBuilder.AllowAnyMethod();
//        policyBuilder.AllowCredentials();
//    });
//});

// Add services to the container.

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

//app.UseCors(MyAllowSpecificOrigins);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseCors("Frontend");

app.UseStaticFiles();

app.Run();
