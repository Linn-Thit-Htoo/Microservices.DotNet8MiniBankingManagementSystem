## Project Overview
This project is implemented using Microservices architecture with Ocelot API Gateway including the following modules:

- Account
- Deposit
- Withdraw
- State & Township
- Transaction History

### [You can check DB script file here](https://github.com/Linn-Thit-Htoo/Microservices.DotNet8MiniBankingManagementSystem/blob/master/script.sql)
### [Here is the postman collection](https://github.com/Linn-Thit-Htoo/Microservices.DotNet8MiniBankingManagementSystem/blob/master/Mini%20Banking%20Management%20System%20Microservices.postman_collection.json)

### For EF Scaffold Db Context
> dotnet ef dbcontext scaffold "Server=.;Database=MiniBankingManagementSystem;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContexts -c AppDbContext
