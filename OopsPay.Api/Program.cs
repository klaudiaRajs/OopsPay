using Microsoft.EntityFrameworkCore;
using Products;
using Transactions;
using Users;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var oopsPayDbCs = builder.Configuration.GetConnectionString("OopsPayDb");
builder.Services.AddDbContext<TransactionOutboxDbContext>(options =>
    options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Transactions")));
builder.Services.AddTransactionDependencies(oopsPayDbCs);
builder.Services.AddDbContext<ProductOutboxDbContext>(options =>
    options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Products")));
builder.Services.AddProductDependencies(oopsPayDbCs);
builder.Services.AddDbContext<UserOutboxDbContext>(options =>
    options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Users")));
builder.Services.AddUserDependencies(oopsPayDbCs);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/hello", () =>
    {
        return "Hello World!";
    })
    .WithName("Hello"); 
app.Run();