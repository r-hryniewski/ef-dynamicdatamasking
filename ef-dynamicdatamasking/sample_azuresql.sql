-- Execute on master

CREATE LOGIN testuser WITH PASSWORD = N'Abcd1234'
GO

--Execute on your db
CREATE TABLE [dbo].[Person] (
  [Name] nvarchar(100) NOT NULL,
  [LastName] nvarchar(100) MASKED WITH (FUNCTION = 'partial(1, "***", 0)') NOT NULL,
  [DateOfBirth] date MASKED WITH (FUNCTION = 'default()') NOT NULL,
  [Rating] bigint MASKED WITH (FUNCTION = 'default()') NOT NULL )
GO
 
INSERT INTO [dbo].[Person] 
  VALUES ('Rafal', 'Hryniewski', '1988-05-16', 100) 
GO

CREATE USER testuser FROM LOGIN testuser
GO

ALTER ROLE db_datareader ADD MEMBER testuser
GO

ALTER ROLE db_datawriter ADD MEMBER testuser
GO

--test permissions with this statement, results should be masked
EXECUTE AS USER = 'testuser'
SELECT *
  FROM [dbo].[Person]
GO