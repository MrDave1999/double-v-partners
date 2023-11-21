# double-v-partners
A sample web application that uses .NET/Angular.

Default credentials:
- **UserName:** MrDave1999
- **Password:** 123456789

## Backend
This project was generated with [dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/) version 7.0.400.

### Technologies used

- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-7.0?view=aspnetcore-7.0)
- [Bcrypt.net](https://github.com/BcryptNet/bcrypt.net)
- [DotEnv.Core](https://github.com/MrDave1999/dotenv.core)
- [SimpleResults](https://github.com/MrDave1999/SimpleResults)
  - [SimpleResults.AspNetCore](https://github.com/MrDave1999/SimpleResults#integration-with-aspnet-core)
  - [SimpleResults.FluentValidation](https://github.com/MrDave1999/SimpleResults#integration-with-fluent-validation)
- [Enums.NET](https://github.com/TylerBrinkley/Enums.NET)
- [Scrutor.AspNetCore](https://github.com/khellang/Scrutor)
- [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/7.0.0)
- [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql)
- [Dapper](https://github.com/DapperLib/Dapper)

### Installation

- Install [MariaDb Server](https://mariadb.com/downloads/) and set the user as root.
- Run the [double-partners.sql](https://github.com/MrDave1999/double-v-partners/blob/master/backend/double-partners.sql) script to build the database and use the default credentials.
- Create an `.env` file in `backend/src/` directory. Example: `copy .env.example .env`.
- Configure the connection string in the `.env` file.
- Run `dotnet run` for a dev server. Navigate to `http://localhost:5227/swagger/`.

## Frontend

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.0.1.

### Technologies used

- [Angular](https://github.com/angular/angular)
- [Bootstrap](https://github.com/twbs/bootstrap)

### Installation

- Run `npm install` to download the project dependencies.
- Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.
- Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. 
  The application will automatically reload if you change any of the source files.
- Use the default login credentials to create users or persons.
  - **User:** mrdave1999
  - **Pass:** 123456789

