# <img src="/Compentio.Assets/Logo.png" align="left" width="50"> SourceApi

![GitHub](https://img.shields.io/github/license/alekshura/SourceApi)
![GitHub top language](https://img.shields.io/github/languages/top/alekshura/SourceApi)

# Introduction
There are two approaches for Web API implemetation: `code first` and `API first`.
During the `code first` approach developers implement their Web API Controllers, add Swagger/Open API library (there is a number of such libraries. ) to Web API App and deploy it. 
API clients use these definitions to generate or create the client code to consume API.

In second, `API First`, API definition created (Open API `json` or `yaml` format) and using these defintions server and client code, interfaces, DTO's are generated.
This approach is technology agnostic: even non tech person can take part in API design and share it between `Java`, `.NET`, `NodeJS` or `Frontend` teams, which can generate and implement server 
or client code for it.  

`SourceApi` is a code generator that helps to use `API First` approach for .NET Core or .NET 5+ Web API applications:
during design time in Visual Studio IDE it generates abstract base Controller classes and DTO's that can be used by developer to implement the target functionality.

It is based on [Source Generators Additional File Transaformation](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md#additional-file-transformation) feature
where it is possible to be able to transform an external non-C# file into an equivalent C# representation.


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

<img src="/Compentio.Assets/AdditionalFile.png" align="center" width="100%">

You will see generated abstract controllers in 
> Dependencies -> Analyzers -> Compentio.SourceApi > Compentio.SourceApi.Generator.

<img src="/Compentio.Assets/GeneratedFiles.png" align="center" width="100%">


## Interface mapping
Use interfaces to prepare basic mapping. 
