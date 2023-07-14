# PowerUtils.BuildingBlocks.Domain

![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.BuildingBlocks.Domain/main/assets/logo/logo_128x128.png)

***Helpers to create the domain layers***

![Tests](https://github.com/TechNobre/PowerUtils.BuildingBlocks.Domain/actions/workflows/tests.yml/badge.svg)
[![Mutation tests](https://img.shields.io/endpoint?style=flat&url=https%3A%2F%2Fbadge-api.stryker-mutator.io%2Fgithub.com%2FTechNobre%2FPowerUtils.BuildingBlocks.Domain%2Fmain)](https://dashboard.stryker-mutator.io/reports/github.com/TechNobre/PowerUtils.BuildingBlocks.Domain/main)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.BuildingBlocks.Domain&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.BuildingBlocks.Domain)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.BuildingBlocks.Domain&metric=coverage)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.BuildingBlocks.Domain)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.BuildingBlocks.Domain&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.BuildingBlocks.Domain)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.BuildingBlocks.Domain&metric=bugs)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.BuildingBlocks.Domain)

[![NuGet](https://img.shields.io/nuget/v/PowerUtils.BuildingBlocks.Domain.svg)](https://www.nuget.org/packages/PowerUtils.BuildingBlocks.Domain)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.BuildingBlocks.Domain.svg)](https://www.nuget.org/packages/PowerUtils.BuildingBlocks.Domain)
[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.BuildingBlocks.Domain.svg)](https://github.com/TechNobre/PowerUtils.BuildingBlocks.Domain/blob/main/LICENSE)


- [Support](#support-to)
- [How to use](#how-to-use)
- [Interfaces](#Interfaces)
- [EntityBase](#EntityBase)
  - [EntityBase.Equals()](#EntityBase.Equals)
  - [EntityBase.operator ==](#EntityBase.EqualityOperator)
  - [EntityBase.operator !=](#EntityBase.InequalityOperator)
  - [EntityComparer](#IEntityBase.EntityComparer)
- [ValueObjectBase](#ValueObjectBase)
  - [ValueObjectBase.Equals()](#ValueObjectBase.Equals)
  - [ValueObjectBase.operator ==](#ValueObjectBase.EqualityOperator)
  - [ValueObjectBase.operator !=](#ValueObjectBase.InequalityOperator)
- [Specification](#Specification)
- [Contribution](#contribution)
- [License](./LICENSE)
- [Changelog](./CHANGELOG.md)



## Support to <a name="support-to"></a>
- .NET 7.0
- .NET 6.0
- .NET 5.0
- .NET 3.1



## How to use <a name="how-to-use"></a>

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
- For older .NET versions is available `ValueObjectBase` based on `class`;

:warning: **DEPRECATED**

This abstraction for ".NET 5 or later" doesn't provide any additional benefit as it simply restricts the implementation of value objects to records. It's commonly recommended to use `structs`, `record structs`, and similar constructs for value object implementations. Therefore, utilizing the `IValueObjectBase` interface to indicate the implementation as a value object is more than sufficient and isn't restricted to specific implementation types. The implementation will be completely removed after 2024/01/14.

ValueOjects are compared by all properties
```csharp
public record Address : ValueObjectBase
{
    public string Country { get; init; }
    public string Region { get; init; }

    public Address(string country, string region)
    {
        Country = country;
        Region = region;
    }
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



## Contribution<a name="contribution"></a>

If you have any questions, comments, or suggestions, please open an [issue](https://github.com/TechNobre/PowerUtils.BuildingBlocks.Domain/issues/new/choose) or create a [pull request](https://github.com/TechNobre/PowerUtils.BuildingBlocks.Domain/compare)