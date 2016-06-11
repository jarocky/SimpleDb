CREATE TABLE [dbo].[Employee]
(
  Identifier uniqueidentifier not null,
  FirstName nvarchar(64) not null,
  LastName nvarchar(64) not null
)
go

alter table Employee add constraint PK_Employee_Identifier primary key (Identifier)
go