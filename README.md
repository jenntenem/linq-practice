# Manejo de Datos en C# con LINQ

LINQ, Metalenguaje que es soportado en varios lenguajes, sirve para acceder a los datos de manera declarativa.

```
// Crear un proyecto de consola
dotnet new sln -o name-project
cd name-project
dotnet new console -o name-project

// Ejecutar el proyecto
dotnet run
```

## Importación implícita de namespaces

En el `*.csproj` habilitar o desactivar la importación implícita de directivas using globales.

```
<ImplicitUsings>enable</ImplicitUsings>
```

## Importación de datos

Para añadir data directamente al proyecto, se modifica el archivo `*.csproj`.

```
  <ItemGroup>
    <Content Include="data/books.json" />
  </ItemGroup>
```
