
# Getting Started with Classes Schedular

## Install the Package

If you are building with .NET CLI tools then you can also use the following command:

```bash
dotnet add package Teaching.ClassSchedular --version 0.2.0
```

You can also view the package at:
https://www.nuget.org/packages/Teaching.ClassSchedular/0.2.0

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `CustomUrl` | `string` | *Default*: `"http://localhost:3000/class/schedular"` |
| `Environment` | Environment | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |

The API client can be initialized as follows:

```csharp
ClassesSchedular.Standard.ClassesSchedularClient client = new ClassesSchedular.Standard.ClassesSchedularClient.Builder()
    .Environment(ClassesSchedular.Standard.Environment.Production)
    .CustomUrl("http://localhost:3000/class/schedular")
    .Build();
```

## List of APIs

* [API](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/controllers/api.md)

## Classes Documentation

* [Utility Classes](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/utility-classes.md)
* [HttpRequest](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/http-request.md)
* [HttpResponse](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/http-string-response.md)
* [HttpContext](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/http-context.md)
* [HttpClientConfiguration](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/http-client-configuration-builder.md)
* [IAuthManager](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/i-auth-manager.md)
* [ApiException](https://www.github.com/asadali214/class-schedular/tree/0.2.0/doc/api-exception.md)

