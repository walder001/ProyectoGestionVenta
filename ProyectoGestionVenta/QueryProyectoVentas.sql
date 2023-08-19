create database GestionVentas;

go
--Tabla persona
create table persona(
       personaid integer primary key identity,
       tipo_persona varchar(20) not null,
       nombre varchar(100) not null,
       tipo_documento varchar(20) null,
       num_documento varchar(20) null,
       direccion varchar(70) null,
       telefono varchar(20) null,
       email varchar(50) null
);
go
--Tabla rol
create table rol(
       rolId integer primary key identity,
       nombre varchar(30) not null,
       descripcion varchar(100) null,
       estado bit default(1)
);
go
--Tabla usuario
create table usuario(
       usuarioId integer primary key identity,
       rolId integer not null,
       nombre varchar(100) not null,
       tipo_documento varchar(20) null,
       num_documento varchar(20) null,
       direccion varchar(70) null,
       telefono varchar(20) null,
       email varchar(50) not null,
       password varbinary not null,
       estado bit default(1),
       FOREIGN KEY (rolId) REFERENCES rol (rolId)
);
go
--Tabla categoría
create table categoria(
       categoriaId integer primary key identity,
       nombre varchar(50) not null unique,
       descripcion varchar(256) null,
       estado bit default(1)
);
go
--Tabla artículo
create table articulo(
       articuloId integer primary key identity,
       categoriaId integer not null,
       codigo varchar(50) null,
       nombre varchar(100) not null unique,
       precio_venta decimal(11,2) not null,
       stock integer not null,
       descripcion varchar(256) null,
       estado bit default(1),
       FOREIGN KEY (categoriaId) REFERENCES categoria(categoriaId)
);
go
--Tabla ingreso
create table ingreso(
       ingresoId integer primary key identity,
       proveedorId integer not null,
       usuarioId integer not null,
       tipo_comprobante varchar(20) not null,
       serie_comprobante varchar(7) null,
       num_comprobante varchar (10) not null,
       fecha datetime not null,
       impuesto decimal (4,2) not null,
       total decimal (11,2) not null,
       estado varchar(20) not null,
       FOREIGN KEY (proveedorId) REFERENCES persona (personaId),
       FOREIGN KEY (usuarioId) REFERENCES usuario (usuarioId)
);
go
--Tabla detalle_ingreso
create table detalle_ingreso(
       detalle_ingresoId integer primary key identity,
       ingresoId integer not null,
       articuloId integer not null,
       cantidad integer not null,
       precio decimal(11,2) not null,
       FOREIGN KEY (ingresoId) REFERENCES ingreso (ingresoId) ON DELETE CASCADE,
       FOREIGN KEY (articuloId) REFERENCES articulo (articuloId)
);
go
--Tabla venta
create table venta(
       ventaId integer primary key identity,
       clienteId integer not null,
       usuarioId integer not null,
       tipo_comprobante varchar(20) not null,
       serie_comprobante varchar(7) null,
       num_comprobante varchar (10) not null,
       fecha_hora datetime not null,
       impuesto decimal (4,2) not null,
       total decimal (11,2) not null,
       estado varchar(20) not null,
       FOREIGN KEY (clienteId) REFERENCES persona (personaId),
       FOREIGN KEY (usuarioId) REFERENCES usuario (usuarioId)
);
go
--Tabla detalle_venta
create table detalle_venta(
       detalle_ventaId integer primary key identity,
       ventaId integer not null,
       articuloId integer not null,
       cantidad integer not null,
       precio decimal(11,2) not null,
       descuento decimal(11,2) not null,
       FOREIGN KEY (ventaId) REFERENCES venta (ventaId) ON DELETE CASCADE,
       FOREIGN KEY (articuloId) REFERENCES articulo (articuloId)
);
--Tabla Proveedor
create table Proveedor(
        proveedorId integer primary key identity,
        correo varchar(30) not null,
        representante varchar(20) not null,
        direcion varchar(30) not null,
        contactos varchar(20) not null,
        FOREIGN KEY (productoId) REFERENCES prodcuto (productoId)
);