CREATE DATABASE ProyectoG2;
GO

USE ProyectoG2;
GO

-- Tablas sin claves foráneas
CREATE TABLE Roles (
    ID INT PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE Categorias (
    ID INT PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE Marcas (
    ID INT PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE UbicacionesTiendas (
    ID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Direccion NVARCHAR(255),
    Ciudad NVARCHAR(100),
    Pais NVARCHAR(100)
);

-- Tablas 
CREATE TABLE Usuarios (
    ID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    CorreoElectronico NVARCHAR(255),
    Contraseña NVARCHAR(255),
    Rol_ID INT,
    FOREIGN KEY (Rol_ID) REFERENCES Roles(ID)
);

CREATE TABLE Productos (
    ID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(MAX),
    Precio DECIMAL(10, 2),
    Categoria_ID INT,
    Marca_ID INT,
    FOREIGN KEY (Categoria_ID) REFERENCES Categorias(ID),
    FOREIGN KEY (Marca_ID) REFERENCES Marcas(ID)
);

CREATE TABLE Descuentos (
    ID INT PRIMARY KEY,
    Producto_ID INT,
    Descuento DECIMAL(5, 2),
    FOREIGN KEY (Producto_ID) REFERENCES Productos(ID)
);

CREATE TABLE Facturas (
    ID INT PRIMARY KEY,
    Usuario_ID INT,
    Fecha DATETIME,
    Total DECIMAL(10, 2),
    FOREIGN KEY (Usuario_ID) REFERENCES Usuarios(ID)
);

CREATE TABLE Carrito (
    ID INT PRIMARY KEY,
    Usuario_ID INT,
    Producto_ID INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10, 2),
    Total DECIMAL(10, 2),
    FOREIGN KEY (Usuario_ID) REFERENCES Usuarios(ID),
    FOREIGN KEY (Producto_ID) REFERENCES Productos(ID)
);

CREATE TABLE ListaDeseos (
    ID INT PRIMARY KEY,
    Usuario_ID INT,
    Producto_ID INT,
    FOREIGN KEY (Usuario_ID) REFERENCES Usuarios(ID),
    FOREIGN KEY (Producto_ID) REFERENCES Productos(ID)
);