using Microsoft.EntityFrameworkCore;
using Products;
using Transactions;
using Users;

namespace OopsPay;

public static class Bootstrap
{
    public static WebApplicationBuilder AddDbContexts(WebApplicationBuilder builder, string oopsPayDbCs)
    {
        builder.Services.AddDbContext<TransactionOutboxDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Transactions")));
        builder.Services.AddDbContext<TransactionDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Transactions")));
        builder.Services.AddDbContext<UserOutboxFromTransactionDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Transactions")));
        builder.Services.AddDbContext<ProductOutboxFromTransactionsDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Transactions")));
        builder.Services.AddTransactionDependencies(oopsPayDbCs);
        builder.Services.AddDbContext<ProductOutboxDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Products")));
        builder.Services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Products")));
        builder.Services.AddDbContext<TransactionOutboxFromProductDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Products")));
        builder.Services.AddProductDependencies(oopsPayDbCs);
        builder.Services.AddDbContext<UserOutboxDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Users")));
        builder.Services.AddDbContext<TransactionOutboxFromUserDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Users")));
        builder.Services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(oopsPayDbCs, b => b.MigrationsAssembly("OopsPay.Users")));
        builder.Services.AddUserDependencies(oopsPayDbCs);
        return builder;
    }
}