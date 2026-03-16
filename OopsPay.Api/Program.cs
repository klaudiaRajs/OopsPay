using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OopsPay;
using Products;
using Transactions;
using Users;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CreateTransaction>();
builder.Services.AddScoped<TransactionRepository>(); 

var oopsPayDbCs = builder.Configuration.GetConnectionString("OopsPayDb");
builder.Services.AddDbContext<TransactionOutboxDbContext>(options =>
    options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Transactions")));
builder.Services.AddTransactionDependencies(oopsPayDbCs);
builder.Services.AddDbContext<ProductOutboxDbContext>(options =>
    options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Products")));
builder.Services.AddProductDependencies(oopsPayDbCs);
builder.Services.AddDbContext<OutboxDbContexts>(options =>
    options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Users")));
builder.Services.AddDbContext<TransactionOutboxFromUserDbContext>(options =>
    options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Users")));
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Users")));
builder.Services.AddUserDependencies(oopsPayDbCs);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OopsPay API V1");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();
app.MapPost("/transaction", async (
        [FromBody] CreateTransactionRequest createTransactionRequest,
        [FromServices] CreateTransaction createTransaction) =>
    {
        var resposne = await createTransaction.Create(createTransactionRequest);
        return Results.Ok(resposne);
    })
    .WithName("CreateTransaction");
await app.RunAsync();