CREATE PROCEDURE [dbo].[SP_UpdateEmployee]
	@Id int,   
    @LastName nvarchar(50),   
    @FirstName nvarchar(50) ,
	@City nvarchar(50) ,
	@Street nvarchar(150) ,
	@Number nvarchar(10) ,
	@NumberBox nvarchar(10),
	@ZipCode nvarchar(20) ,
	@Country nvarchar(50) ,
	@GSM int
AS  
 BEGIN
	UPDATE dbo.Employee
	SET LastName  = @LastName,
		FirstName = @FirstName,
		City = @City,
		Street = @Street,
		Number = @Number,
		NumberBox = @NumberBox,
		ZipCode = @ZipCode,
		Country = @Country,
		GSM = @GSM
	WHERE Id = @Id
END