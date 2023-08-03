# API

```csharp
APIController aPIController = client.APIController;
```

## Class Name

`APIController`

## Methods

* [Get Classes](../../doc/controllers/api.md#get-classes)
* [Get Class Info](../../doc/controllers/api.md#get-class-info)


# Get Classes

Get all the classes scheduled today for the logged in teacher

```csharp
GetClassesAsync(
    string teacherId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teacherId` | `string` | Query, Required | The unique identity string given to each teacher |

## Response Type

[`Task<List<Class>>`](../../doc/models/containers/class.md)

## Example Usage

```csharp
string teacherId = "axw123";
try
{
    List<Class> result = await aPIController.GetClassesAsync(teacherId);
    result.ForEach(item => item.Match<VoidType>(
        seminar: @case =>
        {
            Console.WriteLine(@case);
            return null;
        },
        lecture: @case =>
        {
            Console.WriteLine(@case);
            return null;
        }));
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Class Info

Get all the details of the provided class

```csharp
GetClassInfoAsync(
    Class body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Class`](../../doc/models/containers/class.md) | Body, Required | There can be only 2 kind of classes for any teacher i.e. OneOf(Seminar, Lecture) |

## Response Type

[`Task<ClassInfo>`](../../doc/models/containers/class-info.md)

## Example Usage

```csharp
Class body = Class.FromSeminar(
    new Seminar
    {
        SeminarId = "sqw123",
        Time = "12:00 PM - 1:00 PM",
        TotalAudience = 90,
    }
);

try
{
    ClassInfo result = await aPIController.GetClassInfoAsync(body);
    result.Match<VoidType>(
        talkInfo: @case =>
        {
            Console.WriteLine(@case);
            return null;
        },
        subjectInfo: @case =>
        {
            Console.WriteLine(@case);
            return null;
        });
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Example Response

```
{
  "topic": "Climate Change",
  "time": "12:00 PM - 1:00 PM",
  "presidentInvited": false,
  "externalGuestsInvited": true
}
```

