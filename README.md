# <img src="/Compentio.Assets/Logo.png" align="left" width="50"> SourceApi

![GitHub](https://img.shields.io/github/license/alekshura/SourceApi)
![GitHub top language](https://img.shields.io/github/languages/top/alekshura/SourceApi)

# Introduction
Two different approaches for Web API implementation often used by development teams: `code first` and `API first`.
During the `code first` approach Web API Controllers are implemented, Swagger/Open API libraries are added to the application and finnaly it deployed.
Open API libraries actually adds a middlewares to application which serve Open API definitions, 
Swagger UI thus the clients can use this definitions to generate code or use test API using UI.    

In second, `API First` approach, API defined in `json` or `yaml` files using [Open API standard](https://swagger.io/specification/) first and after that
server or client code, interfaces or DTO's are generated in application.

This approach is technology agnostic: API can be disigned independently from technologies used in cloud native architecture with a wide tech stack, then 
shared between defferent teams (`Java`, `.NET`, `NodeJS`, `Frontend`, ect.) and ech team can decide about what has to be done with it: to generate only DTO's, or 
create base abstract controllers, with routes, documentation and DTO's or to generate client code for consume the API.

`SourceApi` is a code generator that helps to use `API First` approach for .NET Core 3+ (also .NET 5+) Web API applications:
during design time in Visual Studio IDE it generates abstract base Controllers classes and DTO's that can be used by developer to implement the target functionality.

It is based on [Source Generators Additional File Transaformation](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md#additional-file-transformation) feature
where it is possible to be able to transform an external non-C# file into an equivalent C# representation.

Rico Suter's [NSwag](https://github.com/RicoSuter/NSwag) is used underhood:
- [CSharpControllerGenerator](https://github.com/RicoSuter/NSwag/wiki/CSharpControllerGenerator) is used for abstract base controllers code generation
- [CSharpClientGenerator](https://github.com/RicoSuter/NSwag/wiki/CSharpClientGenerator) actually for DTO's only code generation mode. 

# Installation
Install using nuget package manager:

```console
Install-Package Compentio.SourceApi
```

or `.NET CLI`:

```console
dotnet add package Compentio.SourceApi
```

# How to use
In basic and most simple scenario: add Open API definition file or files (`*.json` and `*.yaml` formats are supported) to you project as `AdditionalFiles`:

>```xml
><ItemGroup>
>   <AdditionalFiles Include="OpenApi/Pets.json">
>     <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
>   </AdditionalFiles>
>   <AdditionalFiles Include="OpenApi/Users.yaml">
>     <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
>   </AdditionalFiles>
> </ItemGroup> 

or in file properties in Visual Studio:

<img src="/Compentio.Assets/AdditionalFile.png" align="center" width="95%">

You will see generated abstract controllers in 
> Dependencies -> Analyzers -> Compentio.SourceApi > Compentio.SourceApi.Generator.

<p align="center">
  <img src="/Compentio.Assets/GeneratedFiles.png" align="center" width="50%">
</p>

>! For now use one Open API file per controller. [Open API Tags](https://swagger.io/docs/specification/grouping-operations-with-tags/) are not supported.

Now you can use these base controllers during implementation of you Web API. The DTO's are generated, routes are defined, documentation for the API methods also used from 
Open API definitions:

```cs
[ApiController]
[ApiConventionType(typeof(DefaultApiConventions))]
public class StoreController : StoreControllerBase
{
	/// <inheritdoc />
	public override Task<IActionResult> DeleteOrder([BindRequired] long orderId)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public override Task<ActionResult<IDictionary<string, int>>> GetInventory()
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public override Task<ActionResult<Order>> GetOrderById([BindRequired] long orderId)
	{
		throw new NotImplementedException();
	}

	/// <inheritdoc />
	public override Task<ActionResult<Order>> PlaceOrder([BindRequired, FromBody] Order body)
	{
		throw new NotImplementedException();
	}
}
```

>! You need to add `<inheritdoc />` tag to show documentation from base class in Swagger.

And example of generated code for base controller class:

```cs

//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.13.2.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v12.0.0.2)) (http://NSwag.org)
// </auto-generated>
//----------------------
#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."

#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."

#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'

#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...

#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."

#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"

#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"

namespace Compentio.SourceApi.WebExample.Controllers
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.13.2.0 (NJsonSchema v10.5.2.0 (Newtonsoft.Json v12.0.0.2))")]
    [Microsoft.AspNetCore.Mvc.Route("api/v1")]
    public abstract class StoreControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>Returns pet inventories by status</summary>
        /// <returns>successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("store/inventory")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IDictionary<string, int>>> GetInventory();
        /// <summary>Place an order for a pet</summary>
        /// <param name = "body">order placed for purchasing the pet</param>
        /// <returns>successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("store/order")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Order>> PlaceOrder([Microsoft.AspNetCore.Mvc.FromBody][Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] Order body);
        /// <summary>Find purchase order by ID</summary>
        /// <param name = "orderId">ID of pet that needs to be fetched</param>
        /// <returns>successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("store/order/{orderId}")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<Order>> GetOrderById([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] long orderId);
        /// <summary>Delete purchase order by ID</summary>
        /// <param name = "orderId">ID of the order that needs to be deleted</param>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("store/order/{orderId}")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> DeleteOrder([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] long orderId);
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.2)")]
    public partial class Order
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("petId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long PetId { get; set; }

        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Quantity { get; set; }

        [Newtonsoft.Json.JsonProperty("shipDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset ShipDate { get; set; }

        /// <summary>Order Status</summary>
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public OrderStatus Status { get; set; }

        [Newtonsoft.Json.JsonProperty("complete", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Complete { get; set; } = false;
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.5.2.0 (Newtonsoft.Json v12.0.0.2)")]
    public enum OrderStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"placed")]
        Placed = 0,
        [System.Runtime.Serialization.EnumMember(Value = @"approved")]
        Approved = 1,
        [System.Runtime.Serialization.EnumMember(Value = @"delivered")]
        Delivered = 2,
    }
}
#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108
#pragma warning restore 3016

```
> The default namespace here is concatenation of you project name and directory of Open API definitions.
> To change namespace see `Configuration`   

# Configuration

To customize the generated code and override defaults `SourceApi` 
[consumes MSBuild properties and metadata](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md#consume-msbuild-properties-and-metadata).

Two configuration properies you can dafine in `*.cproj` file to customize SourceApi generator:
- SourceApi_GeneratorNamespace - you can define namespace for generated classes
- SourceApi_GenerateOnlyContracts - you can generate only DTO's without Controller base classes.

>In a case if properties are not added, default values are used: `SourceApi_GenerateOnlyContracts` is set to `False` and for `SourceApi_GeneratorNamespace` 
>concatenation of you project name and directory of Open API definitions is used

For global configuration (used for all added Open API files) define these parameters in `<PropertyGroup> section:

```xml
<PropertyGroup>
   <TargetFramework>net5.0</TargetFramework>
   <GenerateDocumentationFile>true</GenerateDocumentationFile>
   <NoWarn>$(NoWarn);1591</NoWarn>
   ...
   <SourceApi_GeneratorNamespace>Compentio.SourceApi.WebExample.Controllers</SourceApi_GeneratorNamespace>
   <SourceApi_GenerateOnlyContracts>false</SourceApi_GenerateOnlyContracts>
</PropertyGroup>
 ```


You can also define these parameters per file in `<ItemGroup>`: 

```xml
<ItemGroup>
   <AdditionalFiles Include="OpenApi\Pets.yaml"/>
   <AdditionalFiles Include="OpenApi\Store.yaml" SourceApi_GeneratorNamespace="Compentio.SourceApi.WebExample.WebApi"/>
   <AdditionalFiles Include="OpenApi\Users.yaml" SourceApi_GeneratorNamespace="Compentio.SourceApi.WebExample.WebApi" SourceApi_GenerateOnlyContracts = "true"/>
 </ItemGroup>
```

Here in a case global configuration exists, for `Pets.yaml` global config is used, for `Store.yaml` namespace is overriden and for `Users.yaml` 
`SourceApi_GeneratorNamespace` and `SourceApi_GenerateOnlyContracts` are overriden.

