CREATE TABLE [dbo].[EmployeeRequest]
(
  RequestId uniqueidentifier not null,
  EmployeeIdentifier uniqueidentifier not null
)
go

alter table EmployeeRequest add constraint PK_EmployeeRequest_RequestId_EmployeeIdentifier primary key (RequestId, EmployeeIdentifier)
go
alter table EmployeeRequest add constraint FK_EmployeeRequest_RequestId foreign key (RequestId) references Request (Id)
go
alter table EmployeeRequest add constraint FK_EmployeeRequest_EmployeeIdentifier foreign key (EmployeeIdentifier) references Employee (Identifier)
go