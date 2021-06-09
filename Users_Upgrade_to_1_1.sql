SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChangeHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ChangeHistory](
	[Time] [datetime] NOT NULL,
	[MachineName] [nchar](50) NULL,
	[WinUser] [nchar](50) NULL,
	[IP] [nchar](40) NULL,
	[MAC] [nchar](17) NULL,
	[OpType] [int] NULL,
	[OpTable] [int] NULL,
	[Event] [nchar](300) NOT NULL,
 CONSTRAINT [PK_ChangeTable] PRIMARY KEY CLUSTERED 
(
	[Time] ASC,
	[Event] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Meta]([Data] [nchar](100) NOT NULL) ON [PRIMARY]
GO

exec sp_rename 'Roles', 'RolesEx';
exec sp_rename 'Users', 'UsersEx';
exec sp_rename 'Permission', 'PermissionEx'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Machine_Permissions](
	[MachineID] [nchar](20) NOT NULL,
	[id_p] [int] NOT NULL,
 CONSTRAINT [PK_Machine_Permissions] PRIMARY KEY CLUSTERED 
(
	[MachineID] ASC,
	[id_p] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machines](
	[MachineID] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Machines_1] PRIMARY KEY CLUSTERED 
(
	[MachineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Machine_Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Machine_Permissions_Machines] FOREIGN KEY([MachineID])
REFERENCES [dbo].[Machines] ([MachineID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Machine_Permissions] CHECK CONSTRAINT [FK_Machine_Permissions_Machines]
GO
ALTER TABLE [dbo].[Machine_Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Machine_Permissions_PermissionEx] FOREIGN KEY([id_p])
REFERENCES [dbo].[PermissionEx] ([id_p])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Machine_Permissions] CHECK CONSTRAINT [FK_Machine_Permissions_PermissionEx]
GO


--удаляем все текущие разрешения 
DELETE FROM [dbo].[PermissionEx]
GO

--сбрасываем Foreign Keys
ALTER TABLE [dbo].[Role_Permission]
  DROP CONSTRAINT [FK_Role_Permission_Permission]
GO

ALTER TABLE [dbo].[AddOrRemovePermission]
  DROP CONSTRAINT [FK_AddOrRemovePermission_Permission]
GO

ALTER TABLE [dbo].[Machine_Permissions]
  DROP CONSTRAINT [FK_Machine_Permissions_PermissionEx]
GO

DROP Table [dbo].[PermissionEx]
GO

--создаем таблицу PermissionEx с измененными колонками
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PermissionEx]
(
	[id_p] [int] NOT NULL,
	[permName] [varchar](400) NOT NULL,
	[parameters] [int] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[id_p] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--добавляем Foreign Keys для разрешений
ALTER TABLE [dbo].[AddOrRemovePermission]  WITH CHECK ADD  CONSTRAINT [FK_AddOrRemovePermission_Permission] FOREIGN KEY([id_p])
REFERENCES [dbo].[PermissionEx] ([id_p])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AddOrRemovePermission] CHECK CONSTRAINT [FK_AddOrRemovePermission_Permission]
GO

ALTER TABLE [dbo].[Role_Permission]  WITH CHECK ADD  CONSTRAINT [FK_Role_Permission_Permission] FOREIGN KEY([id_p])
REFERENCES [dbo].[PermissionEx] ([id_p])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Role_Permission] CHECK CONSTRAINT [FK_Role_Permission_Permission]
GO

ALTER TABLE [dbo].[Machine_Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Machine_Permissions_PermissionEx] FOREIGN KEY([id_p])
REFERENCES [dbo].[PermissionEx] ([id_p])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Machine_Permissions] CHECK CONSTRAINT [FK_Machine_Permissions_PermissionEx]
GO

ALTER TABLE [dbo].[Role_Permission]
ADD Deviation float
GO

ALTER TABLE [dbo].[AddOrRemovePermission]
ADD Deviation float
GO