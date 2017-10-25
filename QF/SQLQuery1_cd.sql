SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddNewCuenta]
	@Nick nvarchar(30),
	@Password nvarchar(15),
	@Nombre nvarchar(30),
	@App nvarchar(30),
	@Apm nvarchar(30),
	@col nvarchar(30),
	@cel int
AS
BEGIN
	
    -- Insert statements for procedure here INSERT, UPDATE, DELETE, SELECT
	INSERT INTO Speakers VALUES(null,@Nick,@Password,@Nombre,@App,@Apm,@col,@cel)	
END

GO