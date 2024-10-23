# KayiTech-Backend-API
# Welcome
This readme will server as a guide between developers and documentation of API.
## Guide of development
> [!IMPORTANT]  
> Never push to main or development branch directly. Create a branch of source development and create a pull request 
> [!CAUTION]
> Any unchecked commits to the mina branch will risk failing the server
### Overview
![Untitled Diagram drawio](https://github.com/user-attachments/assets/4c9a1f95-ae40-4589-9618-4b464609c4ec)
### Setup develpment DB
Make sure SQL server is installed

1. Click on the solution to load the project
2. Open the appsettings.json file, and paste this into the file
```json
   "ConnectionStrings": {
    "DefaultConnection": "Data Source=(YOUR DB));Initial Catalog=(YOUR TABLE);Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False"
  }
```
This will ensure that there is a connection to the Database


3. If a migration file exists use:
```
    Update-Database
```
To create and save new schemes
```
    Add-Migration (DBUPDATENAME)
```
```
    Update-Database
```

[Migration help](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs) Use the guide if lost.
Run the update database command to allow for creation of tables in the database.

**Optional**
If you want example data in the DB
run this command in visual studio developer powershell
```
dotnet run seeddata
```

## API documentation
### User account
```
//login
```
