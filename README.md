# Prueba Desarrollador JR NET

### Descripción:

- 📚 La Prueba Técnica para Desarrollador Junior .NET tiene como objetivo desarrollar una aplicación web simplificada de gestión de biblioteca utilizando ASP.NET MVC que permita a los usuarios ver, agregar libros y autores. La aplicación debe utilizar ASP.NET MVC con C# y SQL Server como base de datos.
- 📄La página principal debe mostrar una lista de todos los libros registrados y tener opciones para agregar un nuevo libro y un nuevo autor.

- 🗃️La interacción con la base de datos debe realizarse utilizando Entity Framework.

### Requisitos:
- Los requisitos se encuentran en el archivo Requirements.md

### Herramientas Utilizadas en el Desarrollo

- Entorno de Desarrollo Integrado (IDE):
    Visual Studio 2022

- Gestión de Base de Datos:
    SQL Server 2022

- Control de Versiones:
    Git

> [!NOTE]
> Se hizo uso de las versiones más recientes de cada herramientas


### Clonar el repositorio

```shell
git clone https://github.com/lace04/Prueba-Desarrollador-JR-NET.git
```



### Ejecutar Script de la base de datos

El archivo script se encuentra en la carpeta 📂 DB


### 🔗 Cadena de conexión SQL

En el archivo GestionBiblioteca\GestionBiblioteca.Server\appsettings.json cambiar

- servername
- usuario
- password

```SQL
    "cadenaSQL": "Server=servername; Database=DBGESTIONBIBLIOTECA; User Id=usuario; Password=password; TrustServerCertificate=true;"
```

> [!WARNING]
> Cualquier dato incorrecto provocara un funcionamiento incorrecto entre la API y la aplicación.


### Iniciar la aplicación 🚀

- Ejecutar aplicación
- Clic derecho en el proyecto GestionBiblioteca.Client
  - Depurar
  - Iniciar nueva instancia
- Se hace uso de Blazor y Bootsrap en el frontend. 🏜️

<h2>Screenshots</h2>

![sc1](https://github.com/lace04/Prueba-Desarrollador-JR-NET/assets/73793929/51767a40-3b5d-47bc-a2e9-13a781884acd)


![sc2](https://github.com/lace04/Prueba-Desarrollador-JR-NET/assets/73793929/53039ae3-9822-42d0-9461-0bb906bbffa5)


<h2>Diagrama entidad relación de la base de datos</h2>

![MER](https://github.com/lace04/Prueba-Desarrollador-JR-NET/assets/73793929/de3e19ef-4977-4370-a018-dbccbb2e5a61)


### Repositorio

```shell
https://github.com/lace04/Prueba-Desarrollador-JR-NET.git
```

## Authors

- [@lace04](https://www.github.com/lace04)
