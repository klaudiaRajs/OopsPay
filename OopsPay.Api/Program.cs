using Contracts.Transactions;
using Microsoft.AspNetCore.Mvc;
using OopsPay;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CreateTransaction>();
builder.Services.AddScoped<TransactionRepository>(); 

var oopsPayDbCs = builder.Configuration.GetConnectionString("OopsPayDb");
builder = Bootstrap.AddDbContexts(builder, oopsPayDbCs);

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