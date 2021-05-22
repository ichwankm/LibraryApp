# LibraryApp
LibraryApp

using :
- Database = Microsoft SQL Server 2018
- Backend = REST API .NET core 3.1
- Frontend = React JS 17.0.2

Steps :

1. Open Script File scriptDBLibraryApp.sql in folder Database and then running script in SQL Server

2. Open LibraryApplication.sln in folder LibraryApplication with Visual Studio

3. Change Data Source ConnectionStrings in appsettings.json file and match with your SQL Server DataSource that contains LibraryDB from previous script run in SQL Server

4. Run LibraryApplication with Visual Studio for run REST API

5. Open react folder with Visual Studio Code

6. Run with Terminal and Command npm start

7. If the data didn't show, Change the REACT_APP_API in .env file folder React\my-app\src with your localhost PATH after running REST API with Visual Studio 
