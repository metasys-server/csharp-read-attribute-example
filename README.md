# README

Simple example of using .Net to read two attributes of a Metasys site.

## Dependencies

* dotnet 6 or greater
* NewtonSoft.Json
* Flurl.Http

## Using

Clone the repos

```bash
git clone https://github.com/metasys-server/csharp-read-attribute-example
```

Open `Program.cs` and locate and modify the following

* `host` Set this to your server host name (for example: `ADX25`)
* `username` Set this to an api user on your system (for example: `api`)
* `password` Set this to a valid password. (Note this is for test purposes only. You should never hard-code passwords for a production system into source code.)
* `object1Id` The identifier of an object you want to read the `presentValue` of.
* `object2Id` The identifier of another object you want to read the `presentValue` of.

When you are dong the values will look something like this:

```csharp
var host = "ADX25";
var username = "api-user";

// For test systems only. Never embed passwords for production systems in your code.
var password = "my-password";

// Object IDs are available within MUI or using GET /objectIdentifiers?fqr={fqr}
var object1Id = "960534d2-7df5-5ed8-884c-164e7a2f280a";
var object2Id = "c82d160b-884c-5eac-bad4-89754f0069e0";
```

Now you can run the app

```bash
> dotnet run
Value 1: 72.5
Value 2: 18.23
```
