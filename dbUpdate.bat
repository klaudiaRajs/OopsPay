dotnet ef database update --project OopsPay.Transactions  --context TransactionOutboxDbContext --startup-project OopsPay.Api
dotnet ef database update --project OopsPay.Products  --context ProductOutboxDbContext --startup-project OopsPay.Api
dotnet ef database update --project OopsPay.Users  --context UserOutboxDbContext --startup-project OopsPay.Api
dotnet ef database update --project OopsPay.Transactions  --context TransactionDbContext --startup-project OopsPay.Api
dotnet ef database update --project OopsPay.Products  --context ProductDbContext --startup-project OopsPay.Api
dotnet ef database update --project OopsPay.Users  --context UserDbContext --startup-project OopsPay.Api