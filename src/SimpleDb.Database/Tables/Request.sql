CREATE TABLE [dbo].[Request]
(
  Id uniqueidentifier not null,
  ClientSymbol nvarchar(64) not null,
  [Description] nvarchar(max) not null,
  RequestStatusId int not null,
  [Date] datetime not null,
  ResolveDate datetime null,
  RequestPriorityId int not null,
  RequestTypeId int not null
)
go

alter table Request add constraint PK_Request_Id primary key (Id)
go
alter table Request add constraint FK_Request_ClientSymbol foreign key (ClientSymbol) references Client (Symbol)
go
alter table Request add constraint FK_Request_RequestStatusId foreign key (RequestStatusId) references RequestStatus (Id)
go
alter table Request add constraint FK_Request_RequestPriorityId foreign key (RequestPriorityId) references RequestPriority (Id)
go
alter table Request add constraint FK_Request_RequestTypeId foreign key (RequestTypeId) references RequestType (Id)
go