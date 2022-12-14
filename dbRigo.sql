GO
CREATE database dbRigo;
SET ANSI_NULLS ON;
GO

USE [dbRigo]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 11/23/2022 6:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumeroOrden] [int] NOT NULL,
	[Cedula] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK_Orden] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenProducto]    Script Date: 11/23/2022 6:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenProducto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Orden_id] [int] NOT NULL,
	[Producto_id] [int] NOT NULL,
	[Cantidad] [nchar](10) NOT NULL,
 CONSTRAINT [PK_OrdenProducto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 11/23/2022 6:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Precio] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orden] ADD  CONSTRAINT [DF_Orden_status]  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[OrdenProducto]  WITH CHECK ADD  CONSTRAINT [FK_OrdenProducto_Orden] FOREIGN KEY([Orden_id])
REFERENCES [dbo].[Orden] ([Id])
GO
ALTER TABLE [dbo].[OrdenProducto] CHECK CONSTRAINT [FK_OrdenProducto_Orden]
GO
ALTER TABLE [dbo].[OrdenProducto]  WITH CHECK ADD  CONSTRAINT [FK_OrdenProducto_Producto] FOREIGN KEY([Producto_id])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[OrdenProducto] CHECK CONSTRAINT [FK_OrdenProducto_Producto]
GO

INSERT INTO [dbo].[Producto] VALUES ('001','Bicicletas',836900),
									('002',	'Equipo Golf',333600),
									('003',	'Patineta',	85000),
									('004',	'Raqueta tenis',89600)									


/****** Object:  StoredProcedure [dbo].[OrdenStoredProcedures]    Script Date: 11/23/2022 6:40:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrdenStoredProcedures]
	@Action nvarchar(50) ,
	@NumeroOrden int =0,	
	@Producto_id int =null,
	@Orden_id int =null,
	@Cedula nvarchar(50) ='',
	@Direccion NVARCHAR(50)='',
	@Cantidad int =0,
	@Total decimal(18,0) =0
AS
BEGIN
	IF @Action = 'crearOrden'
		BEGIN
			SET @NumeroOrden = (SELECT COUNT(Id) + 1 FROM Orden);
			INSERT INTO [dbo].[Orden] (NumeroOrden, Cedula, Direccion, Total) VALUES (@NumeroOrden, @Cedula, @Direccion, @Total)						
			
			SELECT	[Orden].Id,
					[Orden].NumeroOrden,
					[Orden].Cedula,
					[Orden].Direccion,
					[Orden].Total from [dbo].[Orden]
			where Id= @@IDENTITY;
		END

	IF @Action = 'crearOrdenProducto'
		BEGIN
			INSERT INTO [dbo].[OrdenProducto] VALUES (@Orden_id,@Producto_id,@Cantidad)
			SELECT	
					Orden.Id,
					Orden.NumeroOrden,
					Producto.Nombre,
					OrdenProducto.Cantidad,
					OrdenProducto.Cantidad*Producto.Precio as 'Total' 
				from [dbo].[Orden]
					INNER JOIN OrdenProducto ON OrdenProducto.Orden_id = Orden.Id
					INNER JOIN Producto On Producto.Id = OrdenProducto.Producto_id
				WHERE [Orden].Id= @Orden_id		
		END

	IF @Action = 'Guardar'
		BEGIN
			UPDATE [dbo].[Orden]
				SET
					[Cedula] = @Cedula
					,[Direccion] = @Direccion,
					[Total] =@Total,
					[status]=1
				WHERE Orden.NumeroOrden=@NumeroOrden;
				
			SELECT	[Orden].Id,
					[Orden].NumeroOrden,
					[Orden].Cedula,
					[Orden].Direccion,
					[Orden].Total from [dbo].[Orden]
			where NumeroOrden= @NumeroOrden;
		END
	
	


END
GO
