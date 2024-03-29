USE [GenericTemplateApps]
GO
/****** Object:  Table [dbo].[ArchDesign]    Script Date: 2/29/2024 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArchDesign](
	[ArchDesignID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ArchDesignType] PRIMARY KEY CLUSTERED 
(
	[ArchDesignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ArchDesign] ON 

INSERT [dbo].[ArchDesign] ([ArchDesignID], [Description]) VALUES (1, N'MVC Implementation')
INSERT [dbo].[ArchDesign] ([ArchDesignID], [Description]) VALUES (2, N'WebForms Architecture')
INSERT [dbo].[ArchDesign] ([ArchDesignID], [Description]) VALUES (3, N'Windows Forms')
INSERT [dbo].[ArchDesign] ([ArchDesignID], [Description]) VALUES (4, N'MVVM Pattern')
INSERT [dbo].[ArchDesign] ([ArchDesignID], [Description]) VALUES (5, N'MVP Architecture')
SET IDENTITY_INSERT [dbo].[ArchDesign] OFF
GO
/****** Object:  StoredProcedure [dbo].[AddArchDesign]    Script Date: 2/29/2024 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddArchDesign]
    @Description varchar(30)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ArchDesign ([Description])
    VALUES (@Description);

    SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteArchDesign]    Script Date: 2/29/2024 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteArchDesign]
    @ArchDesignID int
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM ArchDesign
    WHERE ArchDesignID = @ArchDesignID;

    SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[ListArchDesign]    Script Date: 2/29/2024 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
=======================================================================================================================================
Author:					Create date:			Description:
Israel Ramirez Garza	05-May-2023				SP encargado del listado de arquitecturas.
=======================================================================================================================================
*/

CREATE PROCEDURE [dbo].[ListArchDesign]
AS

SET NOCOUNT ON

SELECT		ArchDesignID 
			,[Description]
FROM		ArchDesign

SET NOCOUNT OFF
GO
/****** Object:  StoredProcedure [dbo].[SelectArchDesignByID]    Script Date: 2/29/2024 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectArchDesignByID]
    @ArchDesignID int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ArchDesignID, [Description]
    FROM ArchDesign
    WHERE ArchDesignID = @ArchDesignID;

    SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateArchDesign]    Script Date: 2/29/2024 10:20:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateArchDesign]
    @ArchDesignID int,
    @Description varchar(30)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ArchDesign
    SET [Description] = @Description
    WHERE ArchDesignID = @ArchDesignID;

    SET NOCOUNT OFF;
END
GO
