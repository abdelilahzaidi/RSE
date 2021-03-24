CREATE PROCEDURE SP_SearchEmployee
@Search NVARCHAR(MAX)
AS
BEGIN
	SELECT * FROM Employee 
	WHERE Active = 1 
	AND (
		UPPER(Email) LIKE CONCAT('%',UPPER(@Search),'%') 
		OR UPPER(LastName) LIKE CONCAT('%',UPPER(@Search),'%')
		OR UPPER(FirstName) LIKE CONCAT('%',UPPER(@Search),'%')
		)
END