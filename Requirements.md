# GestionBiblioteca

### Objetivo:

Desarrollar una aplicación web simplificada de gestión de biblioteca utilizando ASP.NET MVC que
permita a los usuarios ver, agregar libros y autores.

## Requisitos Generales:

1. [✅] Utilizar ASP.NET MVC con C#.
2. [✅] Base de datos: SQL Server.
3. Se valorará la claridad y estructura del código.

## Requisitos Funcionales:

1. [✅] Página Principal:
   • Mostrar una lista de todos los libros registrados.  
   • Opción para agregar un nuevo libro.  
   • Opción para agregar un nuevo autor.

2. [✅] Gestión de Libros:  
   • Al agregar un nuevo libro, se debe redirigir a una página con un formulario que
   solicite: título y autor (de una lista desplegable de autores existentes).

3. [✅] Gestión de Autores:  
   • Al agregar un nuevo autor, se debe redirigir a una página con un formulario que
   solicite: nombre del autor.

## Requisitos de Base de Datos:

1. [✅] Tablas para crear:
   • Libros: ID, título, autorID (clave foránea).  
   • Autores: AutorID (clave primaria), nombre.
2. [✅] Configurar la relación entre Autores y Libros usando AutorID como clave foránea en Libros.
3. [✅] Utilizar Entity Framework para la interacción con la base de datos.

## Requisitos Adicionales:

1. [✅] Implementación básica de diseño. Se valorará positivamente el uso de Bootstrap u otro
   framework CSS.
2. [✅] Validaciones básicas en los formularios para asegurar que los campos se ingresen
   correctamente.

## Entrega:

1. [] Código fuente en un repositorio Git.
2. [] Script de la base de datos con las tablas y relaciones creadas.
3. [] Documentación breve en el archivo README.md del repositorio Git. Debe incluir:
   • Descripción del proyecto.
   • Pasos para configurar y ejecutar la aplicación.
   • Capturas de pantalla de las principales funcionalidades de la aplicación.
   • Enlace al repositorio en caso de que la documentación se comparta de manera
   separada.
   • Diagrama entidad relación de la base de datos
