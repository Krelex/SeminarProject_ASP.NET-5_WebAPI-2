## How to use :
Download or clone repo, start it with ViusalStudio, set it as StartUp project and start debuging

SeminarApi - https://seminarapi.azurewebsites.net/api/

SeminarMVC - http://algebra-seminar.azurewebsites.net/

## Description :
Project created for Algebra final assignment. SeminarAPI is restfull service and SeminarMVC is application with business logic.
Database created with SQL Server (T-SQL). Attached to SeminarAPI via Entity Framework 'Code First-Existing Database'.
Login function and db are separate from api_db, its Attached to SeminarMVC via Identity Framework (reworked so login and register parameter is username not email).Some views need authorization and some are open.
For fetching/puting data from/to api used System.Net.Http and for serialization/deserialization used Newtonsoft.Json. View created with help of Bootstrap 3.3


Its contain 2 Parts:
* Part 1 "SeminarAPI": WebAPI 2
* Part 2 "SeminarMVC": ASP.NET MVC 5 | Bootstrap 3.3 

## SeminarApi Description :

### Schema

All API access is over HTTP , and accessed from ``` https://seminarapi.azurewebsites.net/api/ ``` all data is sent and received as JSON.

### Resource

Resource which this api is serving are  ``` /Seminar ``` and ``` /Predbiljezbas ``` .

#### Seminar description :

* IdSeminar : int
* Naziv : String
* Opis : String
* Datum : DateTime
* Popounjent : bool
* IdSeminar : int
* Predbiljezbas : IEnumerable<Predbiljezbas>
  
  
#### Predbiljezbas description :

* IdPredbiljezba : int
* Ime : String
* Prezime : String
* Email : String
* Prezime : String
* Telefon : String
* Datum : DateTime
* Active : bool
* IdSeminar : int


#### To GRAB list of Resource use :
```
GET api/{ResourceName}
```

#### To GRAB uniqe Resource use :
```
GET api/{ResourceName}/{id}
```

#### To EDIT Resource use :
```
PUT api/{ResourceName}/{id}
```

#### To ADD Resource use :
```
POST api/{ResourceName}
```
#### To DELETE Resource use :
```
DELETE api/{ResourceName}/{id}
```

#### To SEARCH Resource use :
```
GET api/{ResourceName}/Search/{string}
```

#### To SEARCH Resource use :
```
GET api/{ResourceName}/Search/{string}
```

#### To GET number of Polaznika in Predbiljezba use :
```
GET api/Predbiljezbas/{id}/PolaznikaCount
```

