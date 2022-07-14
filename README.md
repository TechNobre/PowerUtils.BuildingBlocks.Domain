# PowerUtils.BuildingBlocks.Domain

![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.BuildingBlocks.Domain/main/assets/logo/logo_128x128.png)

***Helpers to create the domain layers***

![Tests](https://github.com/TechNobre/PowerUtils.BuildingBlocks.Domain/actions/workflows/test-project.yml/badge.svg)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.BuildingBlocks.Domain&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.BuildingBlocks.Domain)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.BuildingBlocks.Domain&metric=coverage)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.BuildingBlocks.Domain)

[![NuGet](https://img.shields.io/nuget/v/PowerUtils.BuildingBlocks.Domain.svg)](https://www.nuget.org/packages/PowerUtils.BuildingBlocks.Domain)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.BuildingBlocks.Domain.svg)](https://www.nuget.org/packages/PowerUtils.BuildingBlocks.Domain)
[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.BuildingBlocks.Domain.svg)](https://github.com/TechNobre/PowerUtils.BuildingBlocks.Domain/blob/main/LICENSE)



## Support to
- .NET 3.1 or more
- .NET Standard 2.1



## Features

- [Interfaces](#Interfaces)
- [EntityBase](#EntityBase)
  - [EntityBase.Validate()](#EntityBase.Validate)
  - [EntityBase.Equals()](#EntityBase.Equals)
  - [EntityBase.operator ==](#EntityBase.EqualityOperator)
  - [EntityBase.operator !=](#EntityBase.InequalityOperator)
  - [EntityComparer](#IEntityBase.EntityComparer)
- [ValueObjectBase](#ValueObjectBase)
  - [ValueObjectBase.Validate()](#ValueObjectBase.Validate)
  - [ValueObjectBase.Equals()](#ValueObjectBase.Equals)
  - [ValueObjectBase.operator ==](#ValueObjectBase.EqualityOperator)
  - [ValueObjectBase.operator !=](#ValueObjectBase.InequalityOperator)
- [Specification](#Specification)



## Documentation

### How to use

#### Install NuGet package
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.BuildingBlocks.Domain

**Nuget**
```bash
Install-Package PowerUtils.BuildingBlocks.Domain
```

**.NET CLI**
```
dotnet add package PowerUtils.BuildingBlocks.Domain
```



### Interfaces <a name="Interfaces"></a>
- `IAggregateRoot` to set an `entity` as root Entity;
- `IEntityBase` to define a `class` as an entity;
- `IValueObjectBase` to define a `class` or `record` as an ValueObject;



### EntityBase <a name="EntityBase"></a>
- The setter for **Id** to .NET 5 or more is **init** - `public virtual TId Id { get; init; }`
- The setter for **Id** to versions below .NET 5 is **protected** - `public virtual TId Id { get; protected set; }`

Entities are compared by identity (`Id`)

```csharp
public class Client : EntityBase<Guid>
{
    public string Name { get; init; }

    public Client(string name)
        : base(Guid.NewGuid())
        => Name = name;

    public override void Validate()
    {
        if(string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("The name cannot be not null or empty");
        }
    }
}
```


#### EntityBase.Validate() <a name="EntityBase.Validate"></a>
Virtual method that can be override with validations

```csharp
var client = new Client("Nelson Nobre");

try
{
    client.Validate();
}
catch(Exception exception)
{
    // ...
}
```


#### EntityBase.Equals() <a name="EntityBase.Equals"></a>
```csharp
var client1 = new Client("Nelson Nobre"); // Id = 14e3d0d4-e472-4de4-96d2-2992c537c73a
var client2 = new Client("John smith"); // Id = 14e3d0d4-e472-4de4-96d2-2992c537c73a

// result = true
var result = client1.Equals(client2);
```


#### EntityBase.operator == <a name="EntityBase.EqualityOperator"></a>
```csharp
var client1 = new Client("Nelson Nobre"); // Id = 14e3d0d4-e472-4de4-96d2-2992c537c73a
var client2 = new Client("John smith"); // Id = b995cd6c-d2eb-471b-92ad-5c641b90fa82

// result = false
var result = client1 == client2;
```


#### EntityBase.operator != <a name="EntityBase.InequalityOperator"></a>
```csharp
var client1 = new Client("Nelson Nobre"); // Id = 14e3d0d4-e472-4de4-96d2-2992c537c73a
var client2 = new Client("John smith"); // Id = b995cd6c-d2eb-471b-92ad-5c641b90fa82

// result = true
var result = client1 != client2;
```


#### EntityComparer <a name="IEntityBase.EntityComparer"></a>
```csharp
var comparer = EntityComparer<Guid>.Default;
var list = new Dictionary<Client, int>(comparer);

var client1 = new Client("Nelson Nobre"); // Id = 14e3d0d4-e472-4de4-96d2-2992c537c73a
var client2 = new Client("John smith"); // Id = 14e3d0d4-e472-4de4-96d2-2992c537c73a

list.Add(client1, 1);
list.Add(client2, 1);
```



### ValueObjectBase <a name="ValueObjectBase"></a>
- .NET 5 or more has avalidable the `ValueObjectRBase` based on **record**. `public abstract record ValueObjectRBase`
- `ValueObjectCBase` is based on `class`

ValueOjects are compared by all properties

```csharp
public record Address : ValueObjectRBase
{
    public string Country { get; init; }
    public string Region { get; init; }

    public Address(string country, string region)
    {
        Country = country;
        Region = region;
    }

    public override void Validate()
    {
        if(string.IsNullOrWhiteSpace(Country))
        {
            throw new ArgumentException("The country cannot be not null or empty");
        }

        if(string.IsNullOrWhiteSpace(Region))
        {
            throw new ArgumentException("The name region be not null or empty");
        }
    }
}
```


#### ValueObjectBase.Validate() <a name="ValueObjectBase.Validate"></a>
Virtual method that can be override with validations

```csharp
var address = new Address("Lisbon", "Portugal");

try
{
    address.Validate();
}
catch(Exception exception)
{
    // ...
}
```


#### ValueObjectBase.Equals() <a name="ValueObjectBase.Equals"></a>
```csharp
var address1 = new Address("Lisbon", "Portugal");
var address2 = new Address("Algarve", "Portugal");

// result = false
var result = address1.Equals(address2);
```


#### ValueObjectBase.operator == <a name="ValueObjectBase.EqualityOperator"></a>
```csharp
var address1 = new Address("Lisbon", "Portugal");
var address2 = new Address("Lisbon", "Portugal");

// result = true
var result = address1 == address2;
```


#### ValueObjectBase.operator != <a name="ValueObjectBase.InequalityOperator"></a>
```csharp
var address1 = new Address("Lisbon", "Portugal");
var address2 = new Address("Lisbon", "Portugal");

// result = false
var result = address1 != address2;
```



### Specification <a name="Specification"></a>
```csharp
public class AvailableProductSpec : Specification<Product>
{
    public override Expression<Func<Product, bool>> ToExpression()
        => product => !product.Deleted
                    && product.Quantity > 0;
}
...
...
var product = new Product();

if(AvailableProductSpec().IsSatisfiedBy(product))
{
    ...
}
...
...
if(AvailableProductSpec().IsNotSatisfiedBy(product))
{
    ...
}
```



## Contribution

*Help me to help others*



## LICENSE

[MIT](https://github.com/TechNobre/PowerUtils.BuildingBlocks.Domain/blob/main/LICENSE)



## Changelog

[Here](./CHANGELOG.md)
