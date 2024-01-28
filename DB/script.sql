CREATE DATABASE DBGESTIONBIBLIOTECA;

USE DBGESTIONBIBLIOTECA;

CREATE TABLE Autores(
AutorID INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Libros(
ID INT PRIMARY KEY IDENTITY(1,1),
titulo VARCHAR(50) NOT NULL,
autorID INT REFERENCES Autores(AutorID) NOT NULL
)

-- Insertar datos en la tabla Autores
INSERT INTO Autores (nombre)
VALUES ('Gabriel Garc�a M�rquez'),
       ('J.R.R. Tolkien');

-- Insertar datos en la tabla Libros
INSERT INTO Libros (titulo, autorID)
VALUES ('Cien a�os de soledad', 1),
       ('El Se�or de los Anillos: La Comunidad del Anillo', 2);


SELECT * FROM Autores;
SELECT * FROM Libros;