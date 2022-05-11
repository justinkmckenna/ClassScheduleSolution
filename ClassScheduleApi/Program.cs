var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// configure services in startup.cs for older apis

var fileScheduler = new FileScheduleAdapter(); // we create it here.. eager loading
builder.Services.AddSingleton(fileScheduler);

// builder.Services.AddSingleton<FileScheduleAdapter>(); // Lazy loading, creates the first time it needs it (little longer the first time, faster after)

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // kestrel

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// blocking call. this will sit and listen for incoming requests
app.Run();
