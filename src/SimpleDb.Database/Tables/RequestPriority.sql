CREATE TABLE [dbo].[RequestPriority]
(
  Id int not null,
  Name nvarchar(64) not null
)
go

alter table RequestPriority add constraint PK_RequestPriority_Id primary key (Id)
go