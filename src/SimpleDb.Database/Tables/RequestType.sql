CREATE TABLE [dbo].[RequestType]
(
  Id int not null,
  Name nvarchar(64) not null
)
go

alter table RequestType add constraint PK_RequestType_Id primary key (Id)
go