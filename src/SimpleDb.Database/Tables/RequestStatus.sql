CREATE TABLE [dbo].[RequestStatus]
(
  Id int not null,
  Name nvarchar(64) not null
)
go

alter table RequestStatus add constraint PK_RequestStatus_Id primary key (Id)
go