CREATE DATABASE ProyectoG2;
GO

USE ProyectoG2;
GO



-- Tabla Roles 
CREATE TABLE Roles  (
    ID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla Usuarios
CREATE TABLE Usuarios (
    ID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    CorreoElectronico NVARCHAR(255) NOT NULL,
    Contraseña NVARCHAR(255) NOT NULL,
    Rol_ID INT NOT NULL,
    FOREIGN KEY (Rol_ID) REFERENCES Roles(ID)
);

-- Tabla Productos
CREATE TABLE Productos (
    ID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(200) NOT NULL,
    ImagenURL NVARCHAR(MAX),
    Precio DECIMAL(18, 2) NOT NULL
);

-- Tabla UbicacionesTiendas
CREATE TABLE UbicacionesTiendas (
    ID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(255) NOT NULL,
    Ciudad NVARCHAR(100) NOT NULL,
    Pais NVARCHAR(100) NOT NULL
);

-- Tabla Carrito
CREATE TABLE Carrito (
    CarritoID INT PRIMARY KEY IDENTITY,
    ProductoID INT NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL,
    Cantidad INT NOT NULL,
    FOREIGN KEY (ProductoID) REFERENCES Productos(ID)
);


-- Insertar un nuevo rol
INSERT INTO Roles (Nombre)
VALUES ('Admin');

INSERT INTO Roles (Nombre)
VALUES ('Cliente');


-- Insertar un usuario administrador
INSERT INTO Usuarios (Nombre, CorreoElectronico, Contraseña, Rol_ID)
VALUES ('Admin', 'admin@example.com', 'Admin123', 1);

INSERT INTO Usuarios (Nombre, CorreoElectronico, Contraseña, Rol_ID)
VALUES ('User', 'user@example.com', 'user123', 2);

-- Insertar datos en la tabla UbicacionTienda
INSERT INTO UbicacionesTiendas (Nombre, Direccion, Ciudad, Pais)
VALUES ('Tienda A', 'Calle 123, Colonia Centro', 'Ciudad de México', 'México');

INSERT INTO UbicacionesTiendas (Nombre, Direccion, Ciudad, Pais)
VALUES ('Tienda B', 'Avenida Principal 456', 'Bogotá', 'Colombia');

INSERT INTO UbicacionesTiendas (Nombre, Direccion, Ciudad, Pais)
VALUES ('Tienda C', 'Calle Principal 789', 'Lima', 'Perú');

INSERT INTO UbicacionesTiendas (Nombre, Direccion, Ciudad, Pais)
VALUES ('Tienda D', 'Carrera 10, Barrio Norte', 'Buenos Aires', 'Argentina');

INSERT INTO UbicacionesTiendas (Nombre, Direccion, Ciudad, Pais)
VALUES ('Tienda E', 'Rua Principal 321', 'São Paulo', 'Brasil');


-- Insertar datos en la tabla Producto
INSERT INTO Productos (Nombre, Descripcion, ImagenURL, Precio)
VALUES ('iPhone 11', '128 GB - Blanco', 'https://tiendasishop.com/media/catalog/product/m/h/mhdj3lz_a.jpg?optimize=high&bg-color=255,255,255&fit=bounds&height=700&width=700&canvas=700:700&dpr=1%201x',  639.00);

INSERT INTO Productos (Nombre, Descripcion, ImagenURL, Precio)
VALUES ('iPhone SE', '28GB - Medianoche', 'https://tiendasishop.com/media/catalog/product/i/p/iphone_se3_midnight_pdp_image_position-1a_coes_2_1.jpg?optimize=high&bg-color=255,255,255&fit=bounds&height=700&width=700&canvas=700:700', 669.00);

INSERT INTO Productos (Nombre, Descripcion, ImagenURL, Precio)
VALUES ('iPhone 13', '128GB - Blanco', 'https://tiendasishop.com/media/catalog/product/m/l/mlq73lz_a_1.jpg?optimize=high&bg-color=255,255,255&fit=bounds&height=700&width=700&canvas=700:700&dpr=1%201x', 829.00);

INSERT INTO Productos (Nombre, Descripcion, ImagenURL, Precio)
VALUES ('iPhone 15', '128GB - Verde', 'https://tiendasishop.com/media/catalog/product/i/p/iphone15_green_pdp_image_position-1__coes.jpg?optimize=high&bg-color=255,255,255&fit=bounds&height=700&width=700&canvas=700:700&dpr=1%201x', 1119.00);

INSERT INTO Productos (Nombre, Descripcion, ImagenURL, Precio)
VALUES ('iPhone 15 Pro', '128GB - Titanio Blanco', 'https://tiendasishop.com/media/catalog/product/i/p/iphone_15_pro_white_titanium_pdp_image_position-1__coes.jpg?optimize=high&bg-color=255,255,255&fit=bounds&height=700&width=700&canvas=700:700&dpr=1%201x', 1409.00);
