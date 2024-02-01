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


![sc1](https://github.com/lace04/Prueba-Desarrollador-JR-NET/assets/73793929/8406e2c6-acc6-4463-9f6a-7cea1058987b)


![sc2](https://github.com/lace04/Prueba-Desarrollador-JR-NET/assets/73793929/98219757-bae5-47d7-943a-0e12f655ca2e)


![sc3](https://github.com/lace04/Prueba-Desarrollador-JR-NET/assets/73793929/57f15b55-9c8d-40dd-ac7f-9b0670136bdb)

<h2>Diagrama entidad relación de la base de datos</h2>


![MER](https://github.com/lace04/Prueba-Desarrollador-JR-NET/assets/73793929/ebc0fb64-9935-4f86-adc8-523fcaf220a4)


### Repositorio

```shell
https://github.com/lace04/Prueba-Desarrollador-JR-NET.git
```

## Authors

- [@lace04](https://www.github.com/lace04)
