## How to use :
Download or clone repo, start it with ViusalStudio, set it as StartUp project and start debuging

## Description :
Project created for Algebra final assignment. SeminarAPI is restfull service and SeminarMVC is application with business logic.
Database created with SQL Server (T-SQL). Attached to SeminarAPI via Entity Framework 'Code First-Existing Database'.
Login function and db are separate from api_db, its Attached to SeminarMVC via Identity Framework (reworked so login and register parameter is username not email).Some views need authorization and some are open.
For fetching/puting data from/to api used System.Net.Http and for serialization/deserialization used Newtonsoft.Json. View created with help of Bootstrap 3.3


Its contain 2 Parts:

* Part 1 "SeminarAPI": WebAPI 2
* Part 2 "SeminarMVC": ASP.NET MVC 5 | Bootstrap 3.3 
