# Amplifund-Assignment

## How to run

- If you prefer using Visual Studios, you may open the solution, **set the Startup project as Amplifund.Assignment.API.API1**, and run the project. Your default browser will open to the Swagger UI, where you may test the available endpoints.

- If you prefer using the DotNet CLI, from the solution root, run **"dotnet build; dotnet run --project .\Amplifund.Assignment.API.API1\"**. You should then navigate to your preferred browser and hit the URL: **https://localhost:7228/swagger/index.html**. There, you will see the Swagger UI, where you may test the available endpoints.
  - I use DotNet CLI version 8.0.303. The minimum version required to run the API should be 6.0.0 but it has not been tested on any version other than 8.0.303.

- To query the database, you will need the CLI tool **"sqlite3"** installed on your machine. I used SQLite as the database provider so the full database is found at ".\Amplifund.Assignment.Data\app_database.db" from the solution root. The following are a few simple commands to query the available tables.
  - sqlite3 app_database.db "SELECT * FROM State;"    
  - sqlite3 app_database.db "SELECT * FROM Grant;"    
  - sqlite3 app_database.db "SELECT * FROM StateGrant;"    
