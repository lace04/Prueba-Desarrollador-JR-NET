CREATE DATABASE DBGESTIONBIBLIOTECA;

USE DBGESTIONBIBLIOTECA;

CREATE TABLE Autores(
AutorId INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Libros(
LibroId INT PRIMARY KEY IDENTITY(1,1),
titulo VARCHAR(50) NOT NULL,
autorID INT REFERENCES Autores(AutorID) NOT NULL
)

CREATE TABLE Comentarios(
ComentarioId INT PRIMARY KEY IDENTITY(1,1),
comentario VARCHAR(200) NOT NULL,
LibroID INT REFERENCES Libros(LibroId) NOT NULL
)

-- Insertar datos en la tabla Autores
INSERT INTO Autores (nombre)
VALUES ('Gabriel García Márquez'),
       ('J.R.R. Tolkien');

-- Insertar datos en la tabla Libros
INSERT INTO Libros (titulo, autorID)
VALUES ('Cien años de soledad', 1),
       ('El Señor de los Anillos: La Comunidad del Anillo', 2);

-- Insertar datos en la tabla Comentarios
INSERT INTO Comentarios (comentario, LibroID)
VALUES ('Me encantó este libro', 1),
       ('No me gustó mucho', 2);


SELECT * FROM Autores;
SELECT * FROM Libros;
SELECT * FROM Comentarios;