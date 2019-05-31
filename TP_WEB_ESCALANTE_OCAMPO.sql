GO
use master
go
CREATE DATABASE TP_WEB_ESCALANTE_OCAMPO
GO
USE TP_WEB_ESCALANTE_OCAMPO
Go

set dateformat 'dmy'

CREATE TABLE Productos(
    IdProducto INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
    Titulo VARCHAR(50) NOT NULL CHECK (LEN(Titulo) > 0),
    Descripcion VARCHAR(250) NOT NULL CHECK (LEN(Descripcion) > 0)
);

CREATE TABLE Clientes(
    IdCliente INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
    DNI INT UNIQUE NOT NULL CHECK (DNI > 0),
    Nombre VARCHAR(50) NOT NULL CHECK (LEN(Nombre) > 0),
    Apellido VARCHAR(50) NOT NULL CHECK (LEN(Apellido) > 0),
    Email VARCHAR(100) NOT NULL CHECK (LEN(Email) > 0),
    Direccion VARCHAR(50) NOT NULL CHECK (LEN(Direccion) > 0),
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Vouchers(
    Id INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
    CodigoVoucher VARCHAR(32) UNIQUE DEFAULT CONVERT(VARCHAR(32), HashBytes('MD5', CONVERT(varchar, SYSDATETIME(), 121)), 2) CHECK (LEN(CodigoVoucher) = 32),
    Estado BIT NOT NULL DEFAULT 0 CHECK (Estado IN (1, 0)),
    IdCliente INT DEFAULT NULL FOREIGN KEY REFERENCES Clientes(Idcliente),
    IdProducto INT DEFAULT NULL FOREIGN KEY REFERENCES Productos(IdProducto),
    FechaRegistro DATETIME NULL DEFAULT NULL
);

DECLARE @cnt INT = 0;
WHILE @cnt < 1000
BEGIN
   INSERT INTO Vouchers (CodigoVoucher) VALUES (DEFAULT);
   SET @cnt = @cnt + 1;
   WAITFOR DELAY '00:00:00.002'
END;


create procedure SP_AGREGARCLIENTE(
	@DNI INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Email VARCHAR(100),
    @Direccion VARCHAR(50)
)
as
insert into Clientes (DNI,Nombre,Apellido,Email,Direccion,FechaRegistro) values (@DNI,@Nombre,@Apellido,@Email,@Direccion,GETDATE())
