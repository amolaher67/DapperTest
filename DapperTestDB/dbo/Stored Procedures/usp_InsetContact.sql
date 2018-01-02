-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_InsetContact
	@Id         int output,  
    @FirstName  varchar(50),  
    @LastName   varchar(50),      
    @Company    varchar(50),  
    @Title      varchar(50),  
    @Email      varchar(50)  
AS
BEGIN

	INSERT INTO [dbo].[Contacts]  
           ([FirstName],[LastName],[Company],[Title],[Email]) VALUES  
           (@FirstName, @LastName, @Company, @Title, @Email);  

        SET @Id = cast(scope_identity() as int)  

END