using Microsoft.EntityFrameworkCore;
using Transactions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var transactionOutboxCs = builder.Configuration.GetConnectionString("TransactionOutboxDb");
builder.Services.AddDbContext<TransactionOutboxDbContext>(options =>
    options.UseSqlServer(transactionOutboxCs, b => b.MigrationsAssembly("OopsPay.Transactions")));
builder.Services.AddTransactionDependencies(transactionOutboxCs);

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